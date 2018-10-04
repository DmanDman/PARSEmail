using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace Outlook_CSharp1
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmTray());
        }

        public void ReadInBox()
        {            
            Outlook.MAPIFolder inBox = ThisAddIn.Application.ActiveExplorer()
               .Session.GetDefaultFolder(Outlook
               .OlDefaultFolders.olFolderInbox);


        }

    }
}
