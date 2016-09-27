namespace linweiWRMS2._0 {
    partial class ShowPictureForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPictureForm));
            this.kpImageViewer1 = new KaiwaProjects.KpImageViewer();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_picture_upload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_picture_num = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_picture_delete = new System.Windows.Forms.Button();
            this.openFileDialog_upload_picture = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // kpImageViewer1
            // 
            this.kpImageViewer1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.kpImageViewer1.GifAnimation = false;
            this.kpImageViewer1.Image = null;
            this.kpImageViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kpImageViewer1.Location = new System.Drawing.Point(0, -3);
            this.kpImageViewer1.MenuColor = System.Drawing.Color.LightSteelBlue;
            this.kpImageViewer1.MenuPanelColor = System.Drawing.Color.LightSteelBlue;
            this.kpImageViewer1.MinimumSize = new System.Drawing.Size(454, 145);
            this.kpImageViewer1.Name = "kpImageViewer1";
            this.kpImageViewer1.NavigationPanelColor = System.Drawing.SystemColors.Control;
            this.kpImageViewer1.NavigationTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.kpImageViewer1.OpenButton = false;
            this.kpImageViewer1.PreviewButton = false;
            this.kpImageViewer1.PreviewPanelColor = System.Drawing.SystemColors.Control;
            this.kpImageViewer1.PreviewText = "";
            this.kpImageViewer1.PreviewTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.kpImageViewer1.Rotation = 0;
            this.kpImageViewer1.ShowPreview = true;
            this.kpImageViewer1.Size = new System.Drawing.Size(1068, 558);
            this.kpImageViewer1.TabIndex = 0;
            this.kpImageViewer1.TextColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // btn_previous
            // 
            this.btn_previous.FlatAppearance.BorderSize = 0;
            this.btn_previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_previous.Image = ((System.Drawing.Image)(resources.GetObject("btn_previous.Image")));
            this.btn_previous.Location = new System.Drawing.Point(387, 561);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(140, 23);
            this.btn_previous.TabIndex = 1;
            this.btn_previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_next
            // 
            this.btn_next.FlatAppearance.BorderSize = 0;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Image = ((System.Drawing.Image)(resources.GetObject("btn_next.Image")));
            this.btn_next.Location = new System.Drawing.Point(533, 561);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(146, 23);
            this.btn_next.TabIndex = 2;
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_picture_upload
            // 
            this.btn_picture_upload.FlatAppearance.BorderSize = 0;
            this.btn_picture_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_picture_upload.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_picture_upload.Image = ((System.Drawing.Image)(resources.GetObject("btn_picture_upload.Image")));
            this.btn_picture_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_picture_upload.Location = new System.Drawing.Point(869, 561);
            this.btn_picture_upload.Name = "btn_picture_upload";
            this.btn_picture_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_picture_upload.TabIndex = 3;
            this.btn_picture_upload.Text = "上传";
            this.btn_picture_upload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_picture_upload.UseVisualStyleBackColor = true;
            this.btn_picture_upload.Click += new System.EventHandler(this.btn_picture_upload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 566);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "本项目共有图片";
            // 
            // label_picture_num
            // 
            this.label_picture_num.AutoSize = true;
            this.label_picture_num.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_picture_num.ForeColor = System.Drawing.Color.Blue;
            this.label_picture_num.Location = new System.Drawing.Point(107, 566);
            this.label_picture_num.Name = "label_picture_num";
            this.label_picture_num.Size = new System.Drawing.Size(17, 12);
            this.label_picture_num.TabIndex = 5;
            this.label_picture_num.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "张";
            // 
            // btn_picture_delete
            // 
            this.btn_picture_delete.FlatAppearance.BorderSize = 0;
            this.btn_picture_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_picture_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_picture_delete.Image")));
            this.btn_picture_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_picture_delete.Location = new System.Drawing.Point(980, 561);
            this.btn_picture_delete.Name = "btn_picture_delete";
            this.btn_picture_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_picture_delete.TabIndex = 7;
            this.btn_picture_delete.Text = "删除";
            this.btn_picture_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_picture_delete.UseVisualStyleBackColor = true;
            this.btn_picture_delete.Click += new System.EventHandler(this.btn_picture_delete_Click);
            // 
            // openFileDialog_upload_picture
            // 
            this.openFileDialog_upload_picture.FileName = "openFileDialog1";
            // 
            // ShowPictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1067, 585);
            this.Controls.Add(this.btn_picture_delete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_picture_num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_picture_upload);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.kpImageViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShowPictureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配图查看器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowPictureForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KaiwaProjects.KpImageViewer kpImageViewer1;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_picture_upload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_picture_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_picture_delete;
        private System.Windows.Forms.OpenFileDialog openFileDialog_upload_picture;






    }
}