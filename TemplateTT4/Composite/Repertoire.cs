using System;
using System.Collections.Generic;
using System.IO;

namespace TemplateTT4.Composite
{

    public class Repertoire : Project
    {

        public Repertoire(string name) : base(name)
        {
            projects = new List<Project>();
        }

        public List<Project> projects { get; set; }




        public override void operation(string path)
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
                tab += "----";

            Console.WriteLine(tab + " Repertoire: " + name);


            //-------------------------
            path = path + "\\" + name;
            DirectoryInfo di = new DirectoryInfo(path);

            //if (Directory.Exists(path))
            //{
            //    di.Delete();
            //}
            if (!Directory.Exists(path))
            {
                // Try to create the directory.
                di.Create();

            }

            foreach (Project c in projects)
            {
                c.operation(path);
            }
        }

        public void add(Project c)
        {
            c.niveau = this.niveau + 1;
            projects.Add(c);
        }
        public void remove(Project c)
        {
            projects.Remove(c);
        }

        public List<Project> Getprojects()
        {
            return projects;
        }

    }

}
