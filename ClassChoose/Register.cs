using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ClassChoose
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            String name = this.UserText.Text;
            String pwd = this.PwdText.Text;
            JObject jo = new JObject();
            jo.Add(new JProperty("username", name));
            jo.Add(new JProperty("password", pwd));
            this.RegisterButton.Text = "waiting";
            var client = new Client();
            var retInfo = client.RegisterUser(jo);
            if (retInfo == null)
            {
                MessageBox.Show("网络连接失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (retInfo.Code == 0)
            {
                MessageBox.Show("注册成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            else
            {
                MessageBox.Show(retInfo.Msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.RegisterButton.Text = "Register";
            }

        }
    }
}
