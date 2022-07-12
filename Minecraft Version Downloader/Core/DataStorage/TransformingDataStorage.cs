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
    public class TransformingDataStorage : IDataStorage
    {
        private readonly IDataStorage _sourceStorage;
        private readonly IDataStorage _destStorage;

        public TransformingDataStorage(IDataStorage sourceStorage, IDataStorage destStorage)
        {
            _sourceStorage = sourceStorage;
            _destStorage = destStorage;
        }

        public async Task Load()
        {
            await _sourceStorage.Load();
            await _destStorage.Load();
        }

        public async Task Save()
        {
            await _destStorage.Save();
        }

        public bool Contains(string name)
        {
            return _sourceStorage.Contains(name) || _destStorage.Contains(name);
        }

        public T Get<T>(string name)
        {
            if (_destStorage.Contains(name))
                return _destStorage.Get<T>(name);

            if (!_sourceStorage.Contains(name))
                return default;

            var value = _sourceStorage.Get<T>(name);
            _destStorage.Set(name, value);
            return value;
        }

        public void Set<T>(string name, T value)
        {
            _destStorage.Set(name, value);
        }
    }
}