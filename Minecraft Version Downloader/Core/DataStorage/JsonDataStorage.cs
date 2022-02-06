using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft_Server_Downloader.Core.DataStorage
{
    public class JsonDataStorage : IDataStorage
    {
        private const string DATA_FILENAME = "config.json";
        
        private readonly IFileSystem _fileSystem;
        private JObject data;

        public JsonDataStorage(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            data = new JObject();
        }

        public JsonDataStorage() : this(new FileSystem())
        {
        }

        public async Task Load()
        {
            if (!_fileSystem.File.Exists(DATA_FILENAME))
                return;

            using var stream = _fileSystem.FileStream.Create(DATA_FILENAME, FileMode.Open);
            using var reader = new StreamReader(stream);
            var jsonReader = new JsonTextReader(reader);
            data = await JObject.LoadAsync(jsonReader);
        }

        public async Task Save()
        {
            using var stream = _fileSystem.FileStream.Create(DATA_FILENAME, FileMode.OpenOrCreate);
            using var writer = new StreamWriter(stream);
            var jsonWriter = new JsonTextWriter(writer);
            jsonWriter.Formatting = Formatting.Indented;
            
            await data.WriteToAsync(jsonWriter);
        }

        public bool Contains(string name)
        {
            return data.ContainsKey(name);
        }
        
        public T Get<T>(string name)
        {
            var token = data.SelectToken(name);
            return token == null ? default : token.ToObject<T>();
        }

        public void Set<T>(string name, T value)
        {
            var obj = value.GetType().IsArray || value.GetType().IsGenericType 
                ? JToken.FromObject(JArray.FromObject(value)) : JToken.FromObject(JObject.FromObject(value));

            if (data.ContainsKey(name))
                data.Remove(name);

            data.Add(name, obj);
        }
    }
}