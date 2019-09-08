namespace IT_Day01
{
    partial class LanguageSelectForm
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
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // languageComboBox
            // 
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "中文",
            "英文"});
            this.languageComboBox.Location = new System.Drawing.Point(21, 21);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(176, 23);
            this.languageComboBox.TabIndex = 0;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(21, 60);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(176, 36);
            this.selectBtn.TabIndex = 1;
            this.selectBtn.Text = "選擇語系";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // LanguageSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 117);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.languageComboBox);
            this.Name = "LanguageSelectForm";
            this.Text = "LanguageSelectForm";
            this.Load += new System.EventHandler(this.LanguageSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Button selectBtn;
    }
}