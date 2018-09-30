using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Outlook_CSharp1
{
    static class GlobalVar
    {  
        public static string sAppPath = System.IO.Directory.GetCurrentDirectory();
        public static IList<string> sAllFolders; 

        // global function
        public static string HelloWorld()
        {
            return "Hello World";
        }
    }

    public partial class ThisAddIn
    {      

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            InitializeVariables();

            this.Application.NewMail += new Microsoft.Office.Interop.Outlook
            .ApplicationEvents_11_NewMailEventHandler(ThisApplication_NewMail);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void ThisApplication_NewMail()
        {
            Outlook.MAPIFolder inBox = this.Application.ActiveExplorer()
                .Session.GetDefaultFolder(Outlook
                .OlDefaultFolders.olFolderInbox);

            Outlook.Items inBoxItems = inBox.Items;
            Outlook.MailItem newEmail = null;
            Outlook.MAPIFolder destFolder = inBox.Folders["Processed"];
            inBoxItems = inBoxItems.Restrict("[Unread] = true");

            try
            {
                foreach ( object collectionItem in inBoxItems )
                {
                    newEmail = collectionItem as Outlook.MailItem;

                    if ( newEmail != null )
                    {
                        if ( newEmail.Attachments.Count > 0 )
                        {
                            for ( int i = 1; i <= newEmail.Attachments.Count; i++ )
                               
                            {                         
                                string filename = newEmail.Attachments[i].FileName;
                                string subjectName = newEmail.Subject;
                                newEmail.Attachments[i].SaveAsFile
                                    ( @"C:\TestFileSave\" + newEmail.Attachments[i].FileName );
                                newEmail.Move( destFolder );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorInfo = (string)ex.Message
                    .Substring(0, 11);
                if (errorInfo == "Cannot save")
                {
                    System.Windows.Forms.MessageBox.Show(@"Create Folder C:\TestFileSave");
                }
            }
        }

        private void InitializeVariables()
        {
            // Read in the folder names of each "doctor"
            // Each doctor will have his own folder to move pictures to

            JObject o1 = JObject.Parse( File.ReadAllText( GlobalVar.sAppPath + "\\folders.json" ));         
            string folder1 = ( string )o1["folders"][0];
            IList<string> sAllFolders = o1["folders"].Select( t => ( string) t ).ToList();
            GlobalVar.sAllFolders = sAllFolders;
        }

        private void SetFolderStructure()
        {

        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
