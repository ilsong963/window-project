namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tabcontrol = new System.Windows.Forms.TabControl();
            this.tab_new_btn = new System.Windows.Forms.Button();
            this.tab_del_btn = new System.Windows.Forms.Button();
            this.transparency_trackbar = new System.Windows.Forms.TrackBar();
            this.tab_rename_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transparency_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabcontrol
            // 
            this.Tabcontrol.Location = new System.Drawing.Point(12, 13);
            this.Tabcontrol.Name = "Tabcontrol";
            this.Tabcontrol.SelectedIndex = 0;
            this.Tabcontrol.Size = new System.Drawing.Size(270, 270);
            this.Tabcontrol.TabIndex = 3;
            // 
            // tab_new_btn
            // 
            this.tab_new_btn.Location = new System.Drawing.Point(12, 289);
            this.tab_new_btn.Name = "tab_new_btn";
            this.tab_new_btn.Size = new System.Drawing.Size(83, 32);
            this.tab_new_btn.TabIndex = 4;
            this.tab_new_btn.Text = "탭 생성";
            this.tab_new_btn.UseVisualStyleBackColor = true;
            this.tab_new_btn.Click += new System.EventHandler(this.tab_new_btn_click);
            // 
            // tab_del_btn
            // 
            this.tab_del_btn.Location = new System.Drawing.Point(199, 289);
            this.tab_del_btn.Name = "tab_del_btn";
            this.tab_del_btn.Size = new System.Drawing.Size(83, 32);
            this.tab_del_btn.TabIndex = 5;
            this.tab_del_btn.Text = "탭 삭제";
            this.tab_del_btn.UseVisualStyleBackColor = true;
            this.tab_del_btn.Click += new System.EventHandler(this.tab_del_btn_click);
            // 
            // transparency_trackbar
            // 
            this.transparency_trackbar.LargeChange = 1;
            this.transparency_trackbar.Location = new System.Drawing.Point(12, 327);
            this.transparency_trackbar.Maximum = 8;
            this.transparency_trackbar.Minimum = 3;
            this.transparency_trackbar.Name = "transparency_trackbar";
            this.transparency_trackbar.Size = new System.Drawing.Size(270, 45);
            this.transparency_trackbar.TabIndex = 6;
            this.transparency_trackbar.Value = 8;
            this.transparency_trackbar.Scroll += new System.EventHandler(this.transparency_trackbar_Scroll);
            // 
            // tab_rename_btn
            // 
            this.tab_rename_btn.Location = new System.Drawing.Point(105, 289);
            this.tab_rename_btn.Name = "tab_rename_btn";
            this.tab_rename_btn.Size = new System.Drawing.Size(83, 32);
            this.tab_rename_btn.TabIndex = 7;
            this.tab_rename_btn.Text = "탭 이름 변경";
            this.tab_rename_btn.UseVisualStyleBackColor = true;
            this.tab_rename_btn.Click += new System.EventHandler(this.tab_rename_btn_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(294, 368);
            this.Controls.Add(this.tab_rename_btn);
            this.Controls.Add(this.transparency_trackbar);
            this.Controls.Add(this.tab_del_btn);
            this.Controls.Add(this.tab_new_btn);
            this.Controls.Add(this.Tabcontrol);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Collection";
            ((System.ComponentModel.ISupportInitialize)(this.transparency_trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl Tabcontrol;
        private System.Windows.Forms.Button tab_new_btn;
        private System.Windows.Forms.Button tab_del_btn;
        private System.Windows.Forms.TrackBar transparency_trackbar;
        private System.Windows.Forms.Button tab_rename_btn;
    }
}

