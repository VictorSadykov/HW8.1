using System;
using System.IO;
namespace HW8._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test";

            DeleteUnderMinutes(path, 30);
        }

        static void DeleteUnderMinutes(string path, int minutes)
        {
            var directory = new DirectoryInfo(path);

            if (directory.Exists == true)
            {
                var dirs = directory.GetDirectories();
                var files = directory.GetFiles();                

                foreach (var dir in dirs)
                {
                    DeleteUnderMinutes(dir.FullName, minutes);
                    if (DateTime.Now - dir.CreationTime < TimeSpan.FromMinutes(30))
                    {
                        try
                        {
                            dir.Delete();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                }


                foreach (var file in files)
                {
                    if (DateTime.Now - file.CreationTime < TimeSpan.FromMinutes(30))
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                }
            }

            
        }
    }
}
