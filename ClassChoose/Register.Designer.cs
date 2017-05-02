namespace ClassChoose
{
    partial class Register
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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PwdText = new System.Windows.Forms.TextBox();
            this.UserText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.AutoSize = true;
            this.RegisterButton.Location = new System.Drawing.Point(319, 345);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(136, 57);
            this.RegisterButton.TabIndex = 11;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(140, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 30);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(140, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "UserName";
            // 
            // PwdText
            // 
            this.PwdText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PwdText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PwdText.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PwdText.Location = new System.Drawing.Point(370, 210);
            this.PwdText.Name = "PwdText";
            this.PwdText.Size = new System.Drawing.Size(301, 31);
            this.PwdText.TabIndex = 8;
            this.PwdText.UseSystemPasswordChar = true;
            // 
            // UserText
            // 
            this.UserText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserText.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserText.Location = new System.Drawing.Point(370, 76);
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(301, 31);
            this.UserText.TabIndex = 7;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 470);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PwdText);
            this.Controls.Add(this.UserText);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PwdText;
        private System.Windows.Forms.TextBox UserText;
    }
}