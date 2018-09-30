using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outlook_CSharp1
{
    public class ClsConfiguration
    {
        public string ConfigFilePath { get; set; }
        public string DrNames { get; set; }

        public void GetPath( string PathName )
        {
            this.ConfigFilePath = PathName;
        }

        public string ConfigPath()
        {
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            Console.WriteLine("   {0}\n", currentAssem.FullName);
            return currentAssem.FullName;

        }
    }
}
