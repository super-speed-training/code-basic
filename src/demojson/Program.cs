using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace demojson
{
    class Program
    {
        static void Main(string[] args)
        {
            const string InputnFilePath = "Data/input.json";
            const string OutputFilePath = "Data/output.json";

            var jsonString = FileReader.ReadTextFromDataFile(InputnFilePath);
            var student = JsonConvert.DeserializeObject<Student>(jsonString);
            var jsonData = JsonConvert.SerializeObject(student, Formatting.Indented);

            FileReader.WriteTextToDataFile(OutputFilePath, jsonData);
        }
    }
}
