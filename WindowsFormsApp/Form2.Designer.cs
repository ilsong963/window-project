namespace WindowsFormsApp1
{
    partial class Form2
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
            this.tabname_label = new System.Windows.Forms.Label();
            this.tabname_textbox = new System.Windows.Forms.TextBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabname_label
            // 
            this.tabname_label.AutoSize = true;
            this.tabname_label.Location = new System.Drawing.Point(26, 23);
            this.tabname_label.Name = "tabname_label";
            this.tabname_label.Size = new System.Drawing.Size(57, 12);
            this.tabname_label.TabIndex = 1;
            this.tabname_label.Text = "탭 이름 : ";
            // 
            // tabname_textbox
            // 
            this.tabname_textbox.Location = new System.Drawing.Point(109, 19);
            this.tabname_textbox.Name = "tabname_textbox";
            this.tabname_textbox.Size = new System.Drawing.Size(89, 21);
            this.tabname_textbox.TabIndex = 2;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(28, 58);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 3;
            this.ok_btn.Text = "확인";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_bnt_click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(123, 58);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "취소";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_bnt_click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(226, 98);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.tabname_textbox);
            this.Controls.Add(this.tabname_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "탭 이름 설정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tabname_label;
        private System.Windows.Forms.TextBox tabname_textbox;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}