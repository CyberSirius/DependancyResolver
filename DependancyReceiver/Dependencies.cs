using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    class Dependencies
    {
        string projectName;
        string[] dependenciesToBeInstalled;

        public string ProjectName
        {
            get
            {
                return projectName;
            }

            set
            {
                projectName = value;
            }
        }

        public string[] DependenciesToBeInstalled
        {
            get
            {
                return dependenciesToBeInstalled;
            }

            set
            {
                dependenciesToBeInstalled = value;
            }
        }

        public Dependencies(string projectName, string[] dependencies)
        {
            this.ProjectName = projectName;
            this.dependenciesToBeInstalled = dependencies;
        }
    }
}
