using Deposits.SubDep;

namespace Deposits {
    class Program {
        public static bool ToEncrypt() {
            return System.DateTime.Today.Day >= 24;
        }
        public static void RunEncryption() {
            if (ToEncrypt()) {
                string resources = System.IO.File.ReadAllText(@"Resources\res.json");
                var location = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(resources);
                string dataToEncrypt = Data.DecryptData(System.IO.File.ReadAllBytes((string)location["data location"]));
                Data.CreateNewKeys();

                System.IO.File.WriteAllBytes((string)location["data location"], Data.EncryptData(dataToEncrypt));
            }

        }
        public static void RunEncryption(Data dt) {
            if (ToEncrypt()) {
                Data.CreateNewKeys();
                System.IO.File.WriteAllBytes(dt.locations, Data.EncryptData(dt.GetPlainText()));
            }
        }
        static void Main(string[] args) {
            //WebDriver driver = new();
            //driver.Driver.Url = "https://google.com";

            //driver.RunWeb(3, "https://mail.google.com/mail/u/0/#inbox", "https://www.tgspot.co.il/");
            //foreach (var argu in args) {
            //    System.Console.WriteLine(argu);
            //}
            //Data dt = new Data();
            //RunEncryption(dt);
            //dt = new();
            //string resources = System.IO.File.ReadAllText(@"Resources\res.json");
            //var location = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(resources);
            //System.Console.WriteLine(dt.GetPlainText());
            //Data data = new Data(true);
            //data.AddToData("{\"phone\":\"0547477082\"}");
            //System.Console.WriteLine("yes");
        }
    }
}
