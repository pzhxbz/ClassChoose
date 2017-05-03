using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassChoose
{
    public partial class MainActivity : Form
    {

        private ListViewItem lesson;
        private Platform classInfo;
        private Platform choosedClass;
        private String Token;
        private String UserName;
        public MainActivity()
        {
            InitializeComponent();
        }

        private void MainActivity_Load(object sender, EventArgs e)
        {

            var login = new Login();
            while (!login.IsQuit)
            {
                login.ShowDialog();
            }

            if (!login.LoginSuccess)
            {
                this.Close();
                return;
            }
            this.Token = login.Token;
            this.UserName = login.UserName;
            this.ClassChosser.FullRowSelect = true;

            classInfo = new Platform();
            choosedClass = new Platform();

            var client = new Client();
            classInfo = new Platform();
            classInfo.Lesson = client.GetClassInfo();

            var chooseId = client.GetChoosedClass(Token, UserName);

            if (chooseId != null)
            {
                foreach (var id in chooseId)
                {
                    classInfo.SetIsChoose(id, true);
                    var lesson = classInfo.GetClassInfo(id);
                    if (lesson == null)
                    {
                        return;
                    }


                    choosedClass.Lesson.Add(lesson.Copy());
                }
                ChoosedLesson.BeginUpdate();

                choosedClass.SetListView(ChoosedLesson);

                ChoosedLesson.EndUpdate();
            }



            if (classInfo.Lesson == null)
            {
                MessageBox.Show("网络连接失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.ClassChosser.BeginUpdate();

            //lesson = new ListViewItem();

            classInfo.SetListView(ClassChosser);

            /*lesson.Text = "I666666666";
            lesson.SubItems.Add("装逼学");
            lesson.SubItems.Add("炮王");
            lesson.SubItems.Add("999/999");
            this.ClassChosser.Items.Add(lesson);*/

            this.ClassChosser.EndUpdate();




        }

        protected override void OnPrint(PaintEventArgs e)
        {
            base.OnPrint(e);

        }

        private void UpdateInfo()
        {

            var client = new Client();
            classInfo.Lesson.Clear();
            classInfo.Lesson = client.GetClassInfo();

            var chooseId = client.GetChoosedClass(Token, UserName);

            choosedClass.Lesson.Clear();
            foreach (var id in chooseId)
            {
                classInfo.SetIsChoose(id, true);
                var lesson = classInfo.GetClassInfo(id);
                if (lesson == null)
                {
                    return;
                }
                choosedClass.Lesson.Add(lesson.Copy());
            }

            ClassChosser.BeginUpdate();

            classInfo.SetListView(ClassChosser);

            ClassChosser.EndUpdate();

            ChoosedLesson.BeginUpdate();

            choosedClass.SetListView(ChoosedLesson);

            ChoosedLesson.EndUpdate();

        }

        private void ClassChosser_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem choosed = this.ClassChosser.SelectedItems[0];
            String id = choosed.Text;
            String className = choosed.SubItems[1].Text;
            String teacher = choosed.SubItems[2].Text;
            String peopleNum = choosed.SubItems[3].Text;
            if (
                MessageBox.Show("是否选择:" + id + "  " + teacher + "  " + className, "", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information) == DialogResult.OK)
            {
                var client = new Client();
                var retInfo = client.ChooseClass(this.UserName, this.Token, id);
                if (retInfo == null)
                {
                    MessageBox.Show("网络连接失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (retInfo.Code == 0)
                {
                    MessageBox.Show("选课成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    classInfo.SetIsChoose(id, true);
                    ClassInfo choosedLesson = new ClassInfo();
                    choosedLesson.ClassNumber = id;
                    choosedLesson.ClassName = className;
                    choosedLesson.TeacherName = teacher;
                    choosedLesson.RemainingNum = int.Parse(peopleNum.Split('/')[0]);
                    choosedLesson.TotolNum = int.Parse(peopleNum.Split('/')[1]);
                    choosedClass.Lesson.Add(choosedLesson);
                    UpdateInfo();
                }
                else
                {
                    MessageBox.Show(retInfo.Msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChoosedLesson_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem choosed = this.ChoosedLesson.SelectedItems[0];
            String id = choosed.Text;
            String className = choosed.SubItems[1].Text;
            String teacher = choosed.SubItems[2].Text;
            String peopleNum = choosed.SubItems[3].Text;
            if (
                MessageBox.Show("是否退课:" + id + "  " + teacher + "  " + className, "", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information) == DialogResult.OK)
            {
                var client = new Client();
                var retInfo = client.CancelLesson(this.Token, this.UserName, id);
                if (retInfo == null)
                {
                    MessageBox.Show("网络连接失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (retInfo.Code == 0)
                {
                    MessageBox.Show("退课成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    classInfo.SetIsChoose(id, false);
                    choosedClass.RemoveAtId(id);
                    UpdateInfo();
                }
                else
                {
                    MessageBox.Show(retInfo.Msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetInfo_Click(object sender, EventArgs e)
        {
            var window = new DBInfo();
            window.ShowDialog();
        }
    }

    public class ClassInfo
    {
        public String ClassNumber { get; set; }
        public String ClassName { get; set; }
        public String TeacherName { get; set; }
        public int TotolNum;
        public int RemainingNum;
        public bool IsChoose = false;

        public ClassInfo()
        {

        }

        public override string ToString()
        {
            return TeacherName + "-" + ClassName;
        }

        public ClassInfo Copy()
        {
            var result = new ClassInfo();
            result.ClassNumber = this.ClassNumber;
            result.ClassName = this.ClassName;
            result.RemainingNum = this.RemainingNum;
            result.TeacherName = this.TeacherName;
            result.TotolNum = this.TotolNum;
            return result;
        }
    }

    public class Platform
    {
        public List<ClassInfo> Lesson;

        public Platform()
        {
            Lesson = new List<ClassInfo>();
        }

        public void SetListView(ListView view)
        {
            view.Items.Clear();
            foreach (var info in Lesson)
            {
                var item = new ListViewItem();
                if (info.IsChoose)
                {
                    continue;
                }
                item.Text = info.ClassNumber;
                item.SubItems.Add(info.ClassName);
                item.SubItems.Add(info.TeacherName);
                item.SubItems.Add(Convert.ToString(info.RemainingNum) + "/" + Convert.ToString(info.TotolNum));
                view.Items.Add(item);
            }
        }

        public void SetIsChoose(String id, bool flag)
        {
            for (int i = 0; i < Lesson.Count; i++)
            {
                if (id == Lesson[i].ClassNumber)
                {
                    Lesson[i].IsChoose = flag;
                    return;
                }
            }
        }

        public void RemoveAtId(String id)
        {
            foreach (var info in Lesson)
            {
                if (info.ClassNumber == id)
                {
                    Lesson.Remove(info);
                    break;
                }
            }
        }

        public void SetString(ListBox list)
        {
            list.Items.Clear();
            foreach (var info in Lesson)
            {
                list.Items.Add(info);
            }
        }

        public ClassInfo GetClassInfo(String id)
        {
            foreach (var lesson in Lesson)
            {
                if (lesson.ClassNumber == id)
                {
                    return lesson;
                }
            }
            return null;
        }
    }
}
