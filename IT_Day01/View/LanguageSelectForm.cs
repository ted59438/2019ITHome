using System;
using System.Windows.Forms;

namespace IT_Day01
{
    public partial class LanguageSelectForm : Form
    {
        public LanguageSelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 視窗載入時，設定語言預設為中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanguageSelectForm_Load(object sender, EventArgs e)
        {
            languageComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 帶入選擇的語言到主視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectBtn_Click(object sender, EventArgs e)
        {
            IntroductionForm introductionForm = new IntroductionForm(languageComboBox.SelectedIndex);

            introductionForm.FormClosed += introductionForm_FormClosed;

            introductionForm.Show();
            this.Visible = false;
        }

        /// <summary>
        /// 關閉視窗後，重新開啟語系選擇的視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void introductionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
    }
}
