using SQLite.Net.Interop;

namespace AppAula.Model
{
    public interface IConfig
    {
        string DiretorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
