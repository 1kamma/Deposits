using Newtonsoft.Json.Linq;
//using Deposits.SubDep;
namespace Deposits.SubDep {
    class Fnx : WebDriver {
        string Mail;
        string Url;
        WebDriver MailApp;
        JObject Data;
        public Fnx(string url, string mail) {
            Url = url;
            Mail = mail;
            this.Driver.Url = Url;
            Data data = new(true);
            this.Data = (JObject)data.DataJson["humail"];
        }
        public void DefineMailApp() {
            this.MailApp = new();
            MailApp.RunWeb();
        }

    }
}
