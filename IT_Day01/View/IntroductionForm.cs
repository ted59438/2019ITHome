using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace IT_Day01
{
    public partial class IntroductionForm : Form
    {
        public IntroductionForm(int languageIndex)
        {
            string[] language = { "zh-TW", "en-US" };
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language[languageIndex]);
            InitializeComponent();
        }

        /// <summary>
        /// 顯示邀請自我介紹的文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntroductionForm_Load(object sender, EventArgs e)
        {
            loadSaveIntroduction();
            MessageBox.Show(LanguageResources.FormStart);
        }

        /// <summary>
        /// 將自我介紹的資訊顯示到畫面上
        /// </summary>
        private void loadSaveIntroduction()
        {
            IntroductionOBJ introductionOBJ = FileHelper.processRead();

            nameTextBox.Text = introductionOBJ.name;
            homeTownTextBox.Text = introductionOBJ.homeTown;

            birthdate_YearBox.Text = introductionOBJ.birthDate.Year.ToString();
            birthdate_MonthBox.Text = introductionOBJ.birthDate.Month.ToString();
            birthdate_DayBox.Text = introductionOBJ.birthDate.Day.ToString();

            if (introductionOBJ.photo != null)
                photoBox.Image = PhotoHelper.bytesToImage(introductionOBJ.photo);
        }

        /// <summary>
        /// 選擇相片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void photoBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.FileName != "")
            {
                photoBox.Image = Image.FromFile(fileDialog.FileName);
            }
        }

        /// <summary>
        /// 自我介紹按鈕滑鼠偵聽事件：處理按下自我介紹按鈕後要做的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showIntroductionBtn_Click(object sender, EventArgs e)
        {
            IntroductionOBJ introductionOBJ = getIntroductionFromView();
            int yearOld = calculateYearOld(introductionOBJ.birthDate);

            string introductionText = string.Format(LanguageResources.Message_IntrouductionText, introductionOBJ.name, introductionOBJ.homeTown, yearOld);
            MessageBox.Show(introductionText);
        }

        /// <summary>
        /// 計算年紀
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        private int calculateYearOld(DateTime birthDate)
        {
            DateTime todayDate = DateTime.Today;
            int yearOld = todayDate.Year - birthDate.Year;
            if (todayDate.Month < birthDate.Month ||
                (todayDate.Month == birthDate.Month && todayDate.Day < birthDate.Day))
            {
                yearOld = yearOld - 1;
            }

            return yearOld;
        }

        /// <summary>
        /// 生日欄位的鍵盤偵聽事件，讓使用者只能輸入數字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void birthdate_YearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;
            e.Handled = ! (char.IsDigit(inputChar) || char.IsControl(e.KeyChar));
        }

        /// <summary>
        /// 按下「保存個人資訊」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                IntroductionOBJ introductionOBJ = getIntroductionFromView();
                FileHelper.processSave(introductionOBJ);
                MessageBox.Show("保存完成！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 從畫面上的所有欄位取得自我介紹資訊
        /// </summary>
        /// <returns></returns>
        private IntroductionOBJ getIntroductionFromView()
        {
            try
            {
                checkAllColumnIsNotEmpty();
                checkDateIsValidate();

                IntroductionOBJ introductionOBJ = new IntroductionOBJ();

                introductionOBJ.name = nameTextBox.Text;
                introductionOBJ.homeTown = homeTownTextBox.Text;
                introductionOBJ.birthDate = new DateTime(int.Parse(birthdate_YearBox.Text), int.Parse(birthdate_MonthBox.Text), int.Parse(birthdate_DayBox.Text));
                introductionOBJ.photo = PhotoHelper.ImageToBytes(photoBox.Image);

                return introductionOBJ;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        private void checkAllColumnIsNotEmpty()
        {
            // 校驗每個欄位是否輸入
            TextBox[] allTextBox = new TextBox[] { nameTextBox, homeTownTextBox, birthdate_YearBox, birthdate_MonthBox, birthdate_DayBox };
            string[] allTextBoxName = new string[]{LanguageResources.Name, LanguageResources.HomeTown,
                                                   LanguageResources.Birthday_Year, LanguageResources.Birthday_Month, LanguageResources.Birthday_Day };

            StringBuilder errorMsg = new StringBuilder();

            for (int i = 0; i < allTextBox.GetLength(0); i++)
            {
                if (string.IsNullOrEmpty(allTextBox[i].Text))
                {
                    errorMsg.AppendLine(string.Format(LanguageResources.Message_PleaseInput, allTextBoxName[i]));
                }
            }

            if (photoBox.Image == null)
            {
                errorMsg.AppendLine(LanguageResources.Message_NoImage);
            }

            if (errorMsg.ToString() != "")
            {
                throw new Exception(errorMsg.ToString());
            }
        }

        /// <summary>
        /// 校驗日期格式是否正確
        /// </summary>
        private void checkDateIsValidate()
        {
            if (!Regex.IsMatch(birthdate_YearBox.Text, @"\d") || !Regex.IsMatch(birthdate_MonthBox.Text, @"\d") || !Regex.IsMatch(birthdate_DayBox.Text, @"\d"))
            {
                throw new Exception(LanguageResources.Message_BirthdayNeedNum);
            }
        }

        /// <summary>
        /// 自訂函式：判斷是否為整數
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool stringIsInt(string num)
        {
            int tryParse;

            return int.TryParse(num, out tryParse);
        }
    }
}
