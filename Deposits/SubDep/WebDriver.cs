using OpenQA.Selenium.Firefox;
namespace Deposits.SubDep {
    class WebDriver {
        FirefoxOptions options = new();
        FirefoxProfile profile = new();
        public FirefoxDriver Driver;
        private void SetProfile() {
            this.profile.SetPreference("browser.download.folderList", 2);
            this.profile.SetPreference("browser.download.manager.showWhenStarting", false);
            this.profile.SetPreference("browser.download.dir", "D:/Neutral Folder/");
            this.profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "attachment/csv, text/plain, application/octet-stream, application/binary, text/csv, application/csv, application/excel, text/comma-separated-values, text/xml, application/xml, application/xls, excel/xls, application/excel 97-2003,application/Microsoft Excel 97-2003 Worksheet, application/vnd.ms-excel");
            this.profile.SetPreference("browser.helperApps.neverAsk.openFile", "application/PDF, application/FDF, application/XFDF, application/LSL, application/LSO, application/LSS, application/IQY, application/RQY, application/XLK, application/XLS, application/XLT, application/POT application/PPS, application/PPT, application/DOS, application/DOT, application/WKS, application/BAT, application/PS, application/EPS, application/WCH, application/WCM, application/WB1, application/WB3, application/RTF, application/DOC, application/MDB, application/MDE, application/WBK, application/WB1, application/WCH, application/WCM, application/AD, application/ADP, application/vnd.ms-excel");
            this.profile.SetPreference("browser.download.panel.shown", false);
        }
        private void SetOption() {
            this.options.Profile = this.profile;
            this.options.AddArgument("--lang=EN");
        }
        public WebDriver() {
            //System.IO.Path.Join("bins\\geckodriver.exe");
            this.Driver = new($"bins", options);
        }
        public void RunWeb(int timeToWait = 0, params string[] urls) {
            //System.Timers.Timer timer = new(timeToWait * 1000);
            foreach (var url in urls) {
                this.Driver.Url = url;
                System.Threading.Thread.Sleep(timeToWait * 1000);
            }
        }
    }
}
