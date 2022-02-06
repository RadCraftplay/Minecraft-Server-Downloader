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