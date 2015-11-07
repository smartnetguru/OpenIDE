using Ionic.Zip;
using OpenIDE.Core;
using System;
using System.IO;

namespace PluginCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Arguments(args);
            using (var z = new ZipFile())
            {
                Console.WriteLine("Compiling... ");

                switch (a["target"])
                {
                    case "plugin":
                        compilePlugin(a, z);

                        break;
                    case "library":
                        compileLibrary(a, z);

                        break;
                }

                z.Save(Environment.CurrentDirectory + "\\" + a["output"]);
            }

            Console.WriteLine("Done");
        }

        private static void compilePlugin(Arguments a, ZipFile z)
        {
            
        }

        private static void compileLibrary(Arguments a, ZipFile z)
        {
            var src = a["sources"];

            if(src != null)
            {
                var files = Directory.GetFiles(src);

                foreach (var item in files)
                {
                    z.AddFile(item, "/");
                }
            }
        }
    }
}