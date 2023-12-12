using Microsoft.Extensions.Configuration;

namespace OnlineStoresManager.Abstractions
{
    public static class ConfigurationExtensions
    {
        public static TSection Bind<TSection>(this IConfiguration configuration, string sectionKey)
            where TSection : class, new()
        {
            TSection section = new TSection();
            configuration.Bind(sectionKey, section);

            return section;
        }
    }
}
