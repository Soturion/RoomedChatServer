using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace winFormsChatClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(new chatPage.chatPage(false));
            tabControl1.TabPages.Add(new chatPage.chatPage(true));
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Text = "+";
            tabControl1.Selected += tabControl1_Selected;

            ((chatPage.chatPage)tabControl1.TabPages[0]).ObjectListViewMessages.Width = this.Width - 55;
            ((chatPage.chatPage)tabControl1.TabPages[0]).ObjectListViewMessages.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
            ((chatPage.chatPage)tabControl1.TabPages[0]).ObjectListViewMessages.Height = this.Height - ((chatPage.chatPage)tabControl1.TabPages[0]).ButtonConnect.Location.Y - 180;
        }

        void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(((chatPage.chatPage)e.TabPage).Text == "+")
            {
                chatPage.chatPage insertPage =  new chatPage.chatPage(false);
                tabControl1.TabPages.Insert(tabControl1.TabPages.Count - 1, insertPage);
                tabControl1.SelectTab(insertPage);

                ((chatPage.chatPage)tabControl1.TabPages[tabControl1.TabPages.Count -2]).ObjectListViewMessages.Width = this.Width - 55;
                ((chatPage.chatPage)tabControl1.TabPages[tabControl1.TabPages.Count -2]).ObjectListViewMessages.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
                ((chatPage.chatPage)tabControl1.TabPages[tabControl1.TabPages.Count -2]).ObjectListViewMessages.Height = this.Height - ((chatPage.chatPage)tabControl1.TabPages[0]).ButtonConnect.Location.Y - 180;

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(chatPage.chatPage c in tabControl1.TabPages)
            {
                c.disconnect();
            }
        }

        private void proxyEinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings formSettings = new frmSettings();
            DialogResult d = formSettings.ShowDialog();
            if (d == DialogResult.OK)
            {

            }
        }
    }
}
