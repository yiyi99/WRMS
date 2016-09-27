namespace linweiWRMS2._0 {
    partial class ChangePwdForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePwdForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_oldPwd = new System.Windows.Forms.TextBox();
            this.text_newPwd = new System.Windows.Forms.TextBox();
            this.text_checkPwd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_change_no = new System.Windows.Forms.Button();
            this.btn_change_yes = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "再次输入：";
            // 
            // text_oldPwd
            // 
            this.text_oldPwd.Location = new System.Drawing.Point(117, 12);
            this.text_oldPwd.Name = "text_oldPwd";
            this.text_oldPwd.PasswordChar = '*';
            this.text_oldPwd.Size = new System.Drawing.Size(141, 21);
            this.text_oldPwd.TabIndex = 3;
            // 
            // text_newPwd
            // 
            this.text_newPwd.Location = new System.Drawing.Point(117, 56);
            this.text_newPwd.Name = "text_newPwd";
            this.text_newPwd.PasswordChar = '*';
            this.text_newPwd.Size = new System.Drawing.Size(141, 21);
            this.text_newPwd.TabIndex = 3;
            // 
            // text_checkPwd
            // 
            this.text_checkPwd.Location = new System.Drawing.Point(117, 100);
            this.text_checkPwd.Name = "text_checkPwd";
            this.text_checkPwd.PasswordChar = '*';
            this.text_checkPwd.Size = new System.Drawing.Size(141, 21);
            this.text_checkPwd.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_newPwd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.text_checkPwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text_oldPwd);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 145);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btn_change_no
            // 
            this.btn_change_no.Location = new System.Drawing.Point(179, 179);
            this.btn_change_no.Name = "btn_change_no";
            this.btn_change_no.Size = new System.Drawing.Size(75, 23);
            this.btn_change_no.TabIndex = 4;
            this.btn_change_no.Text = "取消";
            this.btn_change_no.UseVisualStyleBackColor = true;
            this.btn_change_no.Click += new System.EventHandler(this.btn_change_no_Click);
            // 
            // btn_change_yes
            // 
            this.btn_change_yes.Location = new System.Drawing.Point(68, 179);
            this.btn_change_yes.Name = "btn_change_yes";
            this.btn_change_yes.Size = new System.Drawing.Size(75, 23);
            this.btn_change_yes.TabIndex = 4;
            this.btn_change_yes.Text = "确认更改";
            this.btn_change_yes.UseVisualStyleBackColor = true;
            this.btn_change_yes.Click += new System.EventHandler(this.btn_change_yes_Click);
            // 
            // ChangePwdForm
            // 
            this.AcceptButton = this.btn_change_yes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(322, 249);
            this.Controls.Add(this.btn_change_yes);
            this.Controls.Add(this.btn_change_no);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangePwdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_oldPwd;
        private System.Windows.Forms.TextBox text_newPwd;
        private System.Windows.Forms.TextBox text_checkPwd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_change_no;
        private System.Windows.Forms.Button btn_change_yes;
    }
}