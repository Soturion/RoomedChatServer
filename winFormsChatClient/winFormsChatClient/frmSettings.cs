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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        xmlController xmlCntrl = new xmlController();

        private void button1_Click(object sender, EventArgs e)
        {
            xmlCntrl.saveProxySettings(cbProxyEnabled.Checked, cbProxyAuth.Checked, "", "", "");
        }

        private void cbProxyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            tbProxySocket.Enabled = ((CheckBox)sender).Checked;
            cbProxyAuth.Enabled = ((CheckBox)sender).Checked;
            tbProxyUser.Enabled = cbProxyAuth.Enabled;
            tbProxyPass.Enabled = cbProxyAuth.Enabled;

        }

        private void cbProxyAuth_CheckedChanged(object sender, EventArgs e)
        {
            tbProxyUser.Enabled = ((CheckBox)sender).Checked;
            tbProxyPass.Enabled = ((CheckBox)sender).Checked;
        }
    }
}
