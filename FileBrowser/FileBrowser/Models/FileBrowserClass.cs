using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileBrowser.Models
{
    public class FileBrowserClass
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string LastPath { get; set; }
        public string CurrentPath { get; set; }
        public SpaceCount ListCount { get; set; }



        public List<FileBrowserClass> GetDrivs()
        {
            List<FileBrowserClass> list = new List<FileBrowserClass>();
            foreach (var item in Environment.GetLogicalDrives())
            {

                list.Add(new FileBrowserClass { Name = new DirectoryInfo(item).Name, LastPath= string.Empty, Path = new DirectoryInfo(item).FullName, CurrentPath = "root" });
            }
            return list;

        }





        public List<FileBrowserClass> Enter(string path)
        {
            List<FileBrowserClass> FileFolders = new List<FileBrowserClass>();


            if (string.IsNullOrEmpty(path) || path.Equals("undefined"))
                return GetDrivs();

            var dir = new DirectoryInfo(path);
            

            try
            {
                foreach (DirectoryInfo item in dir.GetDirectories())
                {

                    FileFolders.Add(new FileBrowserClass() { CurrentPath = path, Name = item.Name, Path = item.FullName, LastPath = Directory.GetParent(item.FullName).Parent == null ? string.Empty : Directory.GetParent(item.FullName).Parent.FullName });
                }
            }
            catch
            { }


            try
            {

                foreach (FileInfo ite in dir.GetFiles())
                {

                    FileFolders.Add(new FileBrowserClass() { Name = ite.Name, Path = ite.FullName, LastPath = ite.Directory.Parent == null ? string.Empty : ite.Directory.Parent.FullName, CurrentPath = path });

                    FileFolders[0].ListCount = new SpaceCount(path);
                }
            }catch
            {}

                if (FileFolders.Count == 0)
                {
                    try
                    {
                        FileFolders.Add(new FileBrowserClass() { CurrentPath = path, Path = dir.FullName, LastPath = dir.Parent.Parent == null ? string.Empty : dir.Parent.FullName });
                    }
                    catch { }
                }
                ListCount = new SpaceCount(path);


            return FileFolders;
        }

    }
}