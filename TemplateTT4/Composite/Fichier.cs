using System;
using System.IO;

namespace TemplateTT4.Composite
{

    public class Fichier : Project
    {
        public Fichier(string name, string content) : base(name)
        {
            Content = content;
        }
        public string Content { get; set; }

        public override void operation(string path)
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
            {
                tab += "----";
            }

            Console.WriteLine(tab + "Fichier : " + name);



            ///-------------------
            ///
            string fileName = path + "\\" + name + ".cs";
            FileInfo fi = new FileInfo(fileName);

            // Check if file already exists. If yes, delete it.     
            if (fi.Exists)
            {
                fi.Delete();
            }
            // Check if file already exists. If yes, delete it.     
            if (!fi.Exists)
            {
                // Create a new file     
                using (StreamWriter sw = fi.CreateText())
                {
                    //sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                    //sw.WriteLine("Author: Mahesh Chand");
                    //sw.WriteLine("Add one more line ");
                    //sw.WriteLine("Add one more line ");
                    sw.WriteLine(Content);
                }
            }
        }
    }

}
