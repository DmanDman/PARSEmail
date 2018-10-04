using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace Outlook_CSharp1
{
    public partial class FrmTray : Form
    {
        //partial void ThisAddIn();

        public FrmTray()
        {
            InitializeComponent();

        }

        private void FrmTray_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void FrmTray_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        public void TSShow_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        public void TSHide_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        public void FrmTray_Load(object sender, EventArgs e)
        {
            //this.Show();
            this.WindowState = FormWindowState.Normal;
            //this.Hide();
            this.ShowInTaskbar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Timer");
           
        }
    }

    public class MyOutlook
    {
        public 

    }

    public class OutlookStuff
    {
        static void Main()
        {
            ThisApplication_NewMail OutlookItem = new ThisApplication_NewMail();
            //ThisApplication_NewMail() { };
        }      
    }  
}
