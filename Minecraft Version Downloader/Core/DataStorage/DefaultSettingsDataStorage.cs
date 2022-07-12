// This file is part of Minecraft Server Downloader.
// 
// Copyright (C) 2016-2022 Distroir
// 
// Minecraft Server Downloader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Minecraft Server Downloader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// Email: radcraftplay2@gmail.com

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.DataStorage
{
    public class DefaultSettingsDataStorage : IDataStorage
    {
        private readonly Dictionary<string, object> _defaultValues;

        public DefaultSettingsDataStorage(Dictionary<string, object> defaultValues)
        {
            _defaultValues = defaultValues;
        }

        public async Task Load()
        {
            await Task.Run(() => {});
        }

        public Task Save()
        {
            // Read-only
            throw new NotSupportedException("This data storage is read-only");
        }

        public bool Contains(string name)
        {
            return _defaultValues.ContainsKey(name);
        }

        public T Get<T>(string name)
        {
            return (T)_defaultValues[name];
        }

        public void Set<T>(string name, T value)
        {
            // Read-only
            throw new NotSupportedException("This data storage is read-only");
        }
    }
}