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