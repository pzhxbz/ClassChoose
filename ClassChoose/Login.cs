using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassChoose
{
    public partial class Login : Form
    {
        public bool LoginSuccess;
        public String Token;
        public String UserName;
        public bool IsQuit;
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.LoginButton.Text = "Logining";
            JObject jo = new JObject();
            String user = this.UserText.Text;
            String pwd = this.PwdText.Text;
            jo.Add(new JProperty("username", user));
            jo.Add(new JProperty("password", pwd));
            var client = new Client();
            var retInfo = client.Login(jo);
            if (retInfo == null)
            {
                MessageBox.Show("网络连接失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (retInfo.Code == 0)
            {
                UserName = user;
                LoginSuccess = true;
                this.Token = retInfo.token;
                IsQuit = true;
                this.Close();
            }
            LoginSuccess = false;
            MessageBox.Show("用户名或密码错误！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.LoginButton.Text = "Login";
            IsQuit = false;
            //var form = new MainActivity();
            //form.Show(null);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            IsQuit = false;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var reg = new Register();
            reg.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsQuit = true;
        }
    }


}
