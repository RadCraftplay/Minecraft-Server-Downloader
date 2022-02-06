using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.DataStorage
{
    public interface IDataStorage
    {
        Task Load();
        Task Save();
        bool Contains(string name);
        T Get<T>(string name);
        void Set<T>(string name, T value);
    }
}