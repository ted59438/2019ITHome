namespace IT_Day01
{
    partial class IntroductionForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showIntroductionBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.homeTownTextBox = new System.Windows.Forms.TextBox();
            this.photoBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthdate_MonthBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.birthdate_DayBox = new System.Windows.Forms.TextBox();
            this.birthdate_YearBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // showIntroductionBtn
            // 
            resources.ApplyResources(this.showIntroductionBtn, "showIntroductionBtn");
            this.showIntroductionBtn.Name = "showIntroductionBtn";
            this.showIntroductionBtn.UseVisualStyleBackColor = true;
            this.showIntroductionBtn.Click += new System.EventHandler(this.showIntroductionBtn_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // homeTownTextBox
            // 
            resources.ApplyResources(this.homeTownTextBox, "homeTownTextBox");
            this.homeTownTextBox.Name = "homeTownTextBox";
            // 
            // photoBox
            // 
            resources.ApplyResources(this.photoBox, "photoBox");
            this.photoBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.photoBox.Name = "photoBox";
            this.photoBox.TabStop = false;
            this.photoBox.DoubleClick += new System.EventHandler(this.photoBox_DoubleClick);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // birthdate_MonthBox
            // 
            resources.ApplyResources(this.birthdate_MonthBox, "birthdate_MonthBox");
            this.birthdate_MonthBox.Name = "birthdate_MonthBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // birthdate_DayBox
            // 
            resources.ApplyResources(this.birthdate_DayBox, "birthdate_DayBox");
            this.birthdate_DayBox.Name = "birthdate_DayBox";
            // 
            // birthdate_YearBox
            // 
            resources.ApplyResources(this.birthdate_YearBox, "birthdate_YearBox");
            this.birthdate_YearBox.Name = "birthdate_YearBox";
            this.birthdate_YearBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.birthdate_YearBox_KeyPress);
            // 
            // saveBtn
            // 
            resources.ApplyResources(this.saveBtn, "saveBtn");
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // IntroductionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.birthdate_DayBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.birthdate_MonthBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.birthdate_YearBox);
            this.Controls.Add(this.photoBox);
            this.Controls.Add(this.homeTownTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.showIntroductionBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "IntroductionForm";
            this.Load += new System.EventHandler(this.IntroductionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showIntroductionBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox homeTownTextBox;
        private System.Windows.Forms.PictureBox photoBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox birthdate_MonthBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox birthdate_DayBox;
        private System.Windows.Forms.TextBox birthdate_YearBox;
        private System.Windows.Forms.Button saveBtn;
    }
}

