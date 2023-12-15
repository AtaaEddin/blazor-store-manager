using Blazored.LocalStorage;

using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp
{
    public class LocalStorage
    {
        private const string AccessTokenKey = "access_token";
        private const string CultureKey = "culture";
        private const string ThemeKey = "isDarkTheme";

        private readonly ILocalStorageService _storage;

        public LocalStorage(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public async Task<string?> GetAccessToken()
        {
            string? accessToken = await _storage.ContainKeyAsync(AccessTokenKey)
                ? await _storage.GetItemAsStringAsync(AccessTokenKey)
                : null;

            return accessToken;
        }

        public async Task<string?> GetCulture()
        {
            string? culture = await _storage.ContainKeyAsync(CultureKey)
                ? await _storage.GetItemAsStringAsync(CultureKey)
                : null;

            return culture;
        }

        public async Task<bool?> GetTheme()
        {
            string? isDarkThemeStr = await _storage.ContainKeyAsync(ThemeKey)
                ? await _storage.GetItemAsStringAsync(ThemeKey)
                : null;

            return bool.TryParse(isDarkThemeStr, out bool isDarkTheme) ? isDarkTheme : null;
        }

        public async Task RemoveAccessToken()
        {
            await _storage.RemoveItemAsync(AccessTokenKey);
        }

        public async Task SetAccessToken(string accessToken)
        {
            await _storage.SetItemAsStringAsync(AccessTokenKey, accessToken);
        }

        public async Task SetCulture(string culture)
        {
            await _storage.SetItemAsStringAsync(CultureKey, culture);
        }

        public async Task SetTheme(bool isDarkThemeStr)
        {
            await _storage.SetItemAsStringAsync(ThemeKey, isDarkThemeStr ? "1" : "0");
        }
    }
}
