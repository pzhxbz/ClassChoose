namespace ClassChoose
{
    partial class MainActivity
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ClassChosser = new System.Windows.Forms.ListView();
            this.ClassNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClassName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Teacher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PeopleNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.ChoosedLesson = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GetInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClassChosser
            // 
            this.ClassChosser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClassNum,
            this.ClassName,
            this.Teacher,
            this.PeopleNum});
            this.ClassChosser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ClassChosser.LabelWrap = false;
            this.ClassChosser.Location = new System.Drawing.Point(0, 0);
            this.ClassChosser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClassChosser.MultiSelect = false;
            this.ClassChosser.Name = "ClassChosser";
            this.ClassChosser.RightToLeftLayout = true;
            this.ClassChosser.Size = new System.Drawing.Size(555, 718);
            this.ClassChosser.TabIndex = 0;
            this.ClassChosser.UseCompatibleStateImageBehavior = false;
            this.ClassChosser.View = System.Windows.Forms.View.Details;
            this.ClassChosser.DoubleClick += new System.EventHandler(this.ClassChosser_DoubleClick);
            // 
            // ClassNum
            // 
            this.ClassNum.Text = "课程号";
            this.ClassNum.Width = 120;
            // 
            // ClassName
            // 
            this.ClassName.Text = "课程名";
            this.ClassName.Width = 120;
            // 
            // Teacher
            // 
            this.Teacher.Text = "教师";
            this.Teacher.Width = 100;
            // 
            // PeopleNum
            // 
            this.PeopleNum.Text = "人数";
            this.PeopleNum.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1155, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "已选课程";
            // 
            // ChoosedLesson
            // 
            this.ChoosedLesson.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ChoosedLesson.FullRowSelect = true;
            this.ChoosedLesson.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ChoosedLesson.Location = new System.Drawing.Point(1056, 42);
            this.ChoosedLesson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChoosedLesson.MultiSelect = false;
            this.ChoosedLesson.Name = "ChoosedLesson";
            this.ChoosedLesson.Size = new System.Drawing.Size(292, 675);
            this.ChoosedLesson.TabIndex = 2;
            this.ChoosedLesson.UseCompatibleStateImageBehavior = false;
            this.ChoosedLesson.View = System.Windows.Forms.View.Details;
            this.ChoosedLesson.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ChoosedLesson_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "课程号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "课程名";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "教师";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "人数";
            // 
            // GetInfo
            // 
            this.GetInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GetInfo.Location = new System.Drawing.Point(888, 634);
            this.GetInfo.Name = "GetInfo";
            this.GetInfo.Size = new System.Drawing.Size(138, 66);
            this.GetInfo.TabIndex = 3;
            this.GetInfo.Text = "数据库状态";
            this.GetInfo.UseVisualStyleBackColor = false;
            this.GetInfo.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // MainActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.GetInfo);
            this.Controls.Add(this.ChoosedLesson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClassChosser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选课";
            this.Load += new System.EventHandler(this.MainActivity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ClassChosser;
        private System.Windows.Forms.ColumnHeader ClassNum;
        private System.Windows.Forms.ColumnHeader ClassName;
        private System.Windows.Forms.ColumnHeader Teacher;
        private System.Windows.Forms.ColumnHeader PeopleNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ChoosedLesson;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button GetInfo;
    }
}

