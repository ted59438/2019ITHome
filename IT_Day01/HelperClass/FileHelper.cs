using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace IT_Day01
{
    public class FileHelper
    {
        private static string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static string jsonPath = Path.Combine(dirPath, "Introduction.json");
        private static string imagePath = Path.Combine(dirPath, "Photo.jpeg");

        /// <summary>
        /// 自我介紹 JSON讀檔流程
        /// </summary>
        /// <returns></returns>
        public static IntroductionOBJ processRead()
        {
            IntroductionOBJ introductionOBJ;
            JObject introductionJson;

            if (!prepareRead())
            {
                return new IntroductionOBJ();
            }

            introductionJson = readFromJson();
            if (!checkJsonIsVailed(introductionJson))
            {
                return new IntroductionOBJ();
            }

            introductionOBJ = getIntroductionJsonStr(introductionJson);
            introductionOBJ.photo = PhotoHelper.readImageStreamFromFile(imagePath).ToArray() ;

            return introductionOBJ;
        }

        /// <summary>
        /// 讀檔前的檢查
        /// </summary>
        /// <returns></returns>
        private static bool prepareRead()
        {
            if (!Directory.Exists(dirPath) || !File.Exists(jsonPath) || !File.Exists(imagePath))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 讀取JSON文字
        /// </summary>
        /// <returns></returns>
        private static JObject readFromJson()
        {
            string introductionJsonStr = File.ReadAllText(jsonPath);
            JObject introductionJson = (JObject)JsonConvert.DeserializeObject(introductionJsonStr);

            return introductionJson;
            
        }

        /// <summary>
        /// 檢查內容結構是否被破壞
        /// </summary>
        /// <param name="introductionJson"></param>
        /// <returns></returns>
        private static bool checkJsonIsVailed(JObject introductionJson)
        {
            if (introductionJson == null ||
                !introductionJson.ContainsKey("Name") || !introductionJson.ContainsKey("HomeTown") || !introductionJson.ContainsKey("BirthDate"))
            {
                return false;
            }
            else if (!Regex.IsMatch(introductionJson["BirthDate"].ToString().Split('-')[0], @"\d") ||
                     !Regex.IsMatch(introductionJson["BirthDate"].ToString().Split('-')[1], @"\d") ||
                     !Regex.IsMatch(introductionJson["BirthDate"].ToString().Split('-')[2], @"\d"))
            {
                return false;
            }
            else if (!File.Exists(imagePath))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 取得自我介紹資訊
        /// </summary>
        /// <param name="introductionJson"></param>
        /// <returns></returns>
        private static IntroductionOBJ getIntroductionJsonStr(JObject introductionJson)
        {
            IntroductionOBJ introductionOBJ = new IntroductionOBJ();

            introductionOBJ.name = introductionJson["Name"].ToString();
            introductionOBJ.homeTown = introductionJson["HomeTown"].ToString();

            introductionOBJ.birthDate = new DateTime(int.Parse(introductionJson["BirthDate"].ToString().Split('-')[0]),
                                                     int.Parse(introductionJson["BirthDate"].ToString().Split('-')[1]),
                                                     int.Parse(introductionJson["BirthDate"].ToString().Split('-')[2]));

            return introductionOBJ;
        }

        /// <summary>
        /// 自我介紹 寫檔流程
        /// </summary>
        /// <param name="introductionOBJ"></param>
        public static void processSave(IntroductionOBJ introductionOBJ)
        {
            prepareWrite();
            writeToJson(introductionOBJ);
            saveImageToFile(introductionOBJ.photo);
        }

        private static void prepareWrite()
        {
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
        }

        private static void writeToJson(IntroductionOBJ introductionOBJ)
        {
            JObject introductionJson = new JObject();

            introductionJson.Add("Name", introductionOBJ.name);
            introductionJson.Add("HomeTown", introductionOBJ.homeTown);
            introductionJson.Add("BirthDate", string.Format("{0}-{1}-{2}", introductionOBJ.birthDate.Year,
                                                                           introductionOBJ.birthDate.Month,
                                                                           introductionOBJ.birthDate.Day));

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(introductionJson));
        }

        private static void saveImageToFile(byte[] imageByte)
        {
            Image newImage = PhotoHelper.bytesToImage(imageByte);
            newImage.Save(imagePath, ImageFormat.Jpeg);
        }
    }
}
