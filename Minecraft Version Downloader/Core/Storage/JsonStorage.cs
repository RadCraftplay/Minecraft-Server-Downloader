using System.Collections.Generic;
using System.IO;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Storage
{
    public class JsonStorage : ILocalStorage
    {
        private readonly string _filename;

        public JsonStorage(string filename)
        {
            _filename = filename;
        }

        public List<VersionInfoFile> Load()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (TextReader reader = new StreamReader(_filename))
            using (JsonReader jsonReader = new JsonTextReader(reader))
                return serializer.Deserialize<List<VersionInfoFile>>(jsonReader);
        }

        public void Save(List<VersionInfoFile> versions)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (TextWriter writer = new StreamWriter(_filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                serializer.Serialize(jsonWriter, versions);
        }
    }
}
