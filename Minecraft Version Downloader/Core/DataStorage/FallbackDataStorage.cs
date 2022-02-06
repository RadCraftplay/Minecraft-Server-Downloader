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