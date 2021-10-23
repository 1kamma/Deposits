
namespace Deposits.SubDep {
    class UrlActions {
        private string _url;
        private string?[] fields;
        private string?[] data;
        private int timeout;
        public UrlActions(string url, string?[] fields, string?[] data, int timeout = 0) {
            _url = url;
            this.fields = fields;
            this.data = data;
            this.timeout = timeout;
        }
    }
}
