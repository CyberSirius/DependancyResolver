using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> allPackages = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(ReadFile("all_packages.json"));
            Dependencies dependencies = JsonConvert.DeserializeObject<Dependencies>(ReadFile("dependencies.json"));
            for (int i = 0; i < dependencies.DependenciesToBeInstalled.Length; i++)
            {
                string dependency = dependencies.DependenciesToBeInstalled[i];
                RecursiveInstall(dependency, allPackages);
            }

        }
        public static void CreateEmptyFile(string filename)
        {
            File.Create("../../files/installed_modules/" + filename).Dispose();
        }
        public static bool checkIfFileExist(string filename)
        {
            return File.Exists("../../files/installed_modules/" + filename);
        }
        public static string ReadFile(string filename)
        {
            string line;
            StringBuilder fileString = new StringBuilder();
            System.IO.StreamReader file = new System.IO.StreamReader("../../files/" + filename);
            while ((line = file.ReadLine()) != null)
            {
                fileString.Append(line);
            }
            return fileString.ToString();
        }
        public static void RecursiveInstall(string dependency, Dictionary<string, string[]> allPackages)
        {
            Console.WriteLine("Installing " + dependency + ".");
            string[] dependenciesNeeded = allPackages[dependency];
            if (dependenciesNeeded.Length != 0)
            {
                for (int i = 0; i < dependenciesNeeded.Length; i++)
                {
                    Console.WriteLine("In orded to install " + dependency + ", we need to install " + dependenciesNeeded[i] + ".");
                    if (checkIfFileExist(dependenciesNeeded[i]))
                    {
                        Console.WriteLine(dependenciesNeeded[i] + " is already installed.");
                    }
                    else
                    {
                        RecursiveInstall(dependenciesNeeded[i], allPackages);
                    }
                }
            }
            CreateEmptyFile(dependency);
            Console.WriteLine(dependency + " is installed!");
        }

    }
}
