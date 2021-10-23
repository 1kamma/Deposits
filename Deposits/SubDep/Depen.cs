using Newtonsoft.Json;
public class DataDetails {
    private static string resources = System.IO.File.ReadAllText(@"Resources\res.json");
    private static dynamic location = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(resources);
    public static string DataLocation {
        get {
            return (string)location["data location"];
        }
    }
    public static string ExcelLocation {
        get {
            return (string)location["deposit xl"];
        }
    }
}