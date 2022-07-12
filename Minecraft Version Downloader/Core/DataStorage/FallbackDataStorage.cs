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

using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.DataStorage
{
    public class FallbackDataStorage : IDataStorage
    {
        private readonly IDataStorage _defaultStorage;
        private readonly IDataStorage _fallbackStorage;

        public FallbackDataStorage(IDataStorage defaultStorage, IDataStorage fallbackStorage)
        {
            _defaultStorage = defaultStorage;
            _fallbackStorage = fallbackStorage;
        }

        public async Task Load()
        {
            await _defaultStorage.Load();
            await _fallbackStorage.Load();
        }

        public async Task Save()
        {
            await _defaultStorage.Save();
        }

        public bool Contains(string name)
        {
            return _defaultStorage.Contains(name) || _fallbackStorage.Contains(name);
        }

        public T Get<T>(string name)
        {
            if (_defaultStorage.Contains(name))
                return _defaultStorage.Get<T>(name);
            
            return _fallbackStorage.Get<T>(name);
        }

        public void Set<T>(string name, T value)
        {
            _defaultStorage.Set(name, value);
        }
    }
}