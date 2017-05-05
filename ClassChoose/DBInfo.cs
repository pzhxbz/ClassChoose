using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassChoose
{
    public partial class DBInfo : Form
    {
        private Thread update;
        public DBInfo()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void DBInfo_Load(object sender, EventArgs e)
        {
            this.update = new Thread(new ThreadStart(updateInfo));
            update.Start();
        }

        private void updateInfo()
        {
            while (true)
            {
                var client = new Client();
                var DBinfo = client.GetDBinfo();
                this.PostF.Text = DBinfo[0];
                this.personNum.Text = DBinfo[1];
                Thread.Sleep(1000);
            }
        }

        private void DBInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            update.Abort();
        }
    }
}
