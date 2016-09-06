using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileBrowser.Models
{
    public class SpaceCount
    {
        public int Less { get; set; }
        public int Medium { get; set; }
        public int More { get; set; }


        public SpaceCount(string path)
        {

            DirectoryInfo dir = new DirectoryInfo(path);

            try
            {
                foreach (var item in dir.GetFiles())
                {

                    if (item.Length <= (long)10240) { Less++; }

                    if (item.Length > (long)10240 && item.Length <= (long)51200) { Medium++; }

                    if (item.Length > (long)102400) { More++; }

                }
            }
            catch
            {  }

           try {
                foreach (DirectoryInfo dirs in dir.GetDirectories())
                {
                    foreach (FileInfo fls in dirs.GetFiles())
                    {
                        if (fls.Length <= (long)10240) { Less++; }

                        if (fls.Length > (long)10240 && fls.Length <= (long)51200) { Medium++; }

                        if (fls.Length > (long)102400) { More++; }
                    }
                }
            }
                catch
           { }


        }
    }
}