using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Deposits.SubDep {
    class Data {
        string plainTextData;
        public JObject? DataJson { get; }
        public string locations { get; }
        byte[] encryptedData;
        public Data(bool createJson = false) {
            string resources = System.IO.File.ReadAllText(@"Resources\res.json");
            var location = (JObject)JsonConvert.DeserializeObject(resources);
            this.locations = (string)location["data location"];
            this.encryptedData = System.IO.File.ReadAllBytes(locations);
            this.plainTextData = DecryptData(this.encryptedData);
            if (createJson) {
                DataJson = DataObject(this.plainTextData);
            }
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
        public void SetPlainText(string newPlainText) {
            this.plainTextData = newPlainText;
        }
        public void SetPlainText(JObject newPlainText) {
            this.plainTextData = newPlainText.ToString();
        }
        public static byte[] EncryptData(JObject ob) {
            RSA rsaFile = RSA.Create();

            string prive = System.IO.File.ReadAllText(@"D:\pk");
            rsaFile.FromXmlString(prive);

            byte[] Data = Encoding.UTF8.GetBytes(ob.ToString());
            return rsaFile.Encrypt(Data, RSAEncryptionPadding.Pkcs1);
        }
        public static string DecryptData(byte[] data) {
            RSA rsaFile = RSA.Create();
            string prive = System.IO.File.ReadAllText(@"D:\pk");
            rsaFile.FromXmlString(prive);
            string Data = System.Text.Encoding.UTF8.GetString(rsaFile.Decrypt(data, RSAEncryptionPadding.Pkcs1));
            return Data;
        }
        public static JObject DataObject(string data) {
            return (JObject)JsonConvert.DeserializeObject(data);
        }
        public static void SaveEncryptedData(byte[] data, string path) {
            System.IO.File.WriteAllBytes(path, data);
        }
        public void AddToData(string data) {
            try {
                JObject newData = (JObject)JsonConvert.DeserializeObject(data);
                if (DataJson != null) {
                    foreach (var dt in newData) {
                        DataJson.Add(dt.Key, dt.Value);

                    }
                    SaveEncryptedData(EncryptData(DataJson), this.locations);
                }
            } catch {

            }
        }
        public static void RunEncryption(Data dt) {
            if (System.DateTime.Today.Day > 24) {
                CreateNewKeys();
                System.IO.File.WriteAllBytes(dt.locations, EncryptData(dt.GetPlainText()));
            }
        }
        public void RunEncryption() {
            if (System.DateTime.Today.Day > 24) {
                CreateNewKeys();
                System.IO.File.WriteAllBytes(locations, EncryptData(GetPlainText()));
            }
        }

    }
}
