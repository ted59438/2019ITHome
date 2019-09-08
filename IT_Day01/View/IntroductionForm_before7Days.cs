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
            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            string filePath = Path.Combine(dirPath, "Introduction.json");
            string imagePath = Path.Combine(dirPath, "Photo.jpeg");

            // 每次讀寫檔之前，檢查路徑的資料夾與檔案是否存在，避免發生路徑不存在的錯誤
            if (!Directory.Exists(dirPath) || !File.Exists(filePath) || !File.Exists(imagePath))
            {
                return;
            }

            // 從JSON檔讀取先前保存的個人資訊
            string introductionJsonStr = File.ReadAllText(filePath);
            JObject introductionJson = (JObject)JsonConvert.DeserializeObject(introductionJsonStr);

            //讀完資料發現資料空白、結構有缺漏、結構被破壞，不要讀取
            if (introductionJson == null ||
                !introductionJson.ContainsKey("Name") || !introductionJson.ContainsKey("HomeTown") || !introductionJson.ContainsKey("BirthDate"))
            {
                return;
            }
            else
            {
                nameTextBox.Text = introductionJson["Name"].ToString();
                homeTownTextBox.Text = introductionJson["HomeTown"].ToString();

                birthdate_YearBox.Text = introductionJson["BirthDate"].ToString().Split('-')[0];
                birthdate_MonthBox.Text = introductionJson["BirthDate"].ToString().Split('-')[1];
                birthdate_DayBox.Text = introductionJson["BirthDate"].ToString().Split('-')[2];
            }

            photoBox.Image = Image.FromFile(imagePath);
        }
        /// <summary>
        /// 按下「保存個人資訊」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
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

            if (errorMsg.ToString() != "")
            {
                MessageBox.Show(errorMsg.ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 校驗日期格式是否正確
            if (!Regex.IsMatch(birthdate_YearBox.Text, @"\d") || !Regex.IsMatch(birthdate_MonthBox.Text, @"\d") || !Regex.IsMatch(birthdate_DayBox.Text, @"\d"))
            {
                MessageBox.Show(LanguageResources.Message_BirthdayNeedNum, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 檢查有沒有選擇大頭照
            if (photoBox.Image == null)
            {
                MessageBox.Show(LanguageResources.Message_NoImage, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = nameTextBox.Text;
            string homeTown = homeTownTextBox.Text;

            int birthDate_Year = int.Parse(birthdate_YearBox.Text);
            int birthDate_Month = int.Parse(birthdate_MonthBox.Text);
            int birthDate_Day = int.Parse(birthdate_DayBox.Text);

            JObject introductionJson = new JObject();

            introductionJson.Add("Name", name);
            introductionJson.Add("HomeTown", homeTown);
            introductionJson.Add("BirthDate", string.Format("{0}-{1}-{2}", birthDate_Year, birthDate_Month, birthDate_Day));

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            string jsonPath = Path.Combine(dirPath, "Introduction.json");
            string imagePath = Path.Combine(dirPath, "Photo.jpeg");

            // 每次讀寫檔之前，檢查路徑的資料夾與檔案是否存在，避免發生路徑不存在的錯誤
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            // 檔案不存在，產生個人資訊的檔案
            if (!File.Exists(jsonPath))
            {
                File.Create(jsonPath).Close();
            }

            // 保存個人資訊到JSON
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(introductionJson));
            // 保存個人大頭貼到Jpeg 圖片
            photoBox.Image.Save(imagePath, ImageFormat.Jpeg);

            MessageBox.Show("保存完成！", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (errorMsg.ToString() != "")
            {
                MessageBox.Show(errorMsg.ToString());
                return;
            }

            // 校驗日期格式是否正確
            if (!Regex.IsMatch(birthdate_YearBox.Text, @"\d") || !Regex.IsMatch(birthdate_MonthBox.Text, @"\d") || !Regex.IsMatch(birthdate_DayBox.Text, @"\d"))
            {
                MessageBox.Show(LanguageResources.Message_BirthdayNeedNum);
                return;
            }
            // 取得使用者輸入的姓名和家鄉
            string name = nameTextBox.Text;
            string homeTown = homeTownTextBox.Text;

            // 取得當下的日期
            int today_Year = DateTime.Today.Year;
            int today_Month = DateTime.Today.Month;
            int today_Day = DateTime.Today.Day;

            int yearOld;

            // 計算年齡
            int birthDate_Year = int.Parse(birthdate_YearBox.Text);
            int birthDate_Month = int.Parse(birthdate_MonthBox.Text);
            int birthDate_Day = int.Parse(birthdate_DayBox.Text);

            yearOld = today_Year - int.Parse(birthdate_YearBox.Text);
            if (today_Month < birthDate_Month || (today_Month == birthDate_Month && today_Day < birthDate_Day))
            {
                yearOld = yearOld - 1;
            }

            // 顯示自我介紹
            string introductionText = string.Format(LanguageResources.Message_IntrouductionText, name, homeTown, yearOld);

            MessageBox.Show(introductionText);
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

        /// <summary>
        /// 生日欄位的鍵盤偵聽事件，讓使用者只能輸入數字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void birthdate_YearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            e.Handled = !(char.IsDigit(inputChar) || char.IsControl(e.KeyChar));
        }
    }
}
