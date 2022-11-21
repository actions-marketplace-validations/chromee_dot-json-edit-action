using Newtonsoft.Json;

if (args.Length < 3) throw new Exception("コマンドライン引数が足りません");

var jsonPath = args[0];
var fieldPath = args[1];
var fieldValue = args[2];

if (string.IsNullOrEmpty(jsonPath)) throw new Exception("jsonファイルが見つかりません");

var json = File.ReadAllText(jsonPath);
dynamic jsonObject = JsonConvert.DeserializeObject(json);
if (jsonObject == null) throw new Exception("jsonのパースに失敗");

var fieldNames = fieldPath.Split("/");
if (!fieldNames.Any()) throw new Exception("フィールドが指定されていません");

var obj = jsonObject[fieldNames.First()];
var length = fieldNames.Length;
for (var i = 1; i < length; i++)
{
    var fieldName = fieldNames[i];
    var field = obj[fieldName];
    if (field == null) throw new Exception("指定したフィールドが見つかりません");

    if (i == length - 1) obj[fieldName] = fieldValue;
    else obj = obj[fieldName];
}

string output = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
File.WriteAllText(jsonPath, output);
