namespace ClassChoose
{
    partial class DBInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.personNum = new System.Windows.Forms.Label();
            this.PostF = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(321, 18);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(130, 24);
            this.title.TabIndex = 0;
            this.title.Text = "数据库信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(159, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "在线人数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(160, 305);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "请求频率（每分钟）";
            // 
            // personNum
            // 
            this.personNum.AutoSize = true;
            this.personNum.Location = new System.Drawing.Point(584, 129);
            this.personNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.personNum.Name = "personNum";
            this.personNum.Size = new System.Drawing.Size(15, 15);
            this.personNum.TabIndex = 3;
            this.personNum.Text = "0";
            // 
            // PostF
            // 
            this.PostF.AutoSize = true;
            this.PostF.Location = new System.Drawing.Point(584, 305);
            this.PostF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PostF.Name = "PostF";
            this.PostF.Size = new System.Drawing.Size(15, 15);
            this.PostF.TabIndex = 4;
            this.PostF.Text = "0";
            // 
            // DBInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 484);
            this.Controls.Add(this.PostF);
            this.Controls.Add(this.personNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DBInfo_FormClosing);
            this.Load += new System.EventHandler(this.DBInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label personNum;
        private System.Windows.Forms.Label PostF;
    }
}