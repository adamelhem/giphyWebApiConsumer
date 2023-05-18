using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class FileHandler
    {
        public T LoadJsonFile<T>(string filePath)
            =>  JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
    }
}