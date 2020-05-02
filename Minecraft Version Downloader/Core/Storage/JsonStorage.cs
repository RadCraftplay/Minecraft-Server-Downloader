/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016-2020 Distroir

	Minecraft Server Downloader is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	Minecraft Server Downloader is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.

	Email: radcraftplay2@gmail.com
*/
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
