using System.Security.Cryptography;
using System.Text;
namespace Deposits.SubDep {
    class Data {
        string plainTextData;
        string locations;
        byte[] encryptedData;
        public Data() {
            string resources = System.IO.File.ReadAllText(@"Resources\res.json");
            var location = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(resources);
            this.locations = (string)location["data location"];
            this.encryptedData = System.IO.File.ReadAllBytes(locations);
            this.plainTextData = DecryptData(this.encryptedData);
        }
        public static void CreateNewKeys() {
            RSA file = RSA.Create();
            file.KeySize = 8192;
            System.IO.File.WriteAllText(@"D:\pk", file.ToXmlString(true));
            System.IO.File.WriteAllText(@"C:\pk", file.ToXmlString(false));

        }
        //public static void GenerateNewKeys() {
        //    RSA file = RSA.Create();
        //}
        public string GetLocation() {
            return this.locations;
        }
        public string GetPlainText() {
            return this.plainTextData;
        }
        public static byte[] EncryptData(string data) {

            RSA rsaFile = RSA.Create();

            string prive = System.IO.File.ReadAllText(@"D:\pk");
            rsaFile.FromXmlString(prive);

            byte[] Data = Encoding.UTF8.GetBytes(data);
            return rsaFile.Encrypt(Data, RSAEncryptionPadding.Pkcs1);

            //rsaFile.fr

        }
        public static string DecryptData(byte[] data) {
            RSA rsaFile = RSA.Create();
            string prive = System.IO.File.ReadAllText(@"D:\pk");
            rsaFile.FromXmlString(prive);
            string Data = System.Text.Encoding.UTF8.GetString(rsaFile.Decrypt(data, RSAEncryptionPadding.Pkcs1));
            return Data;
        }
    }
}
