using Blazored.LocalStorage;

using System.Threading.Tasks;

namespace OnlineStoresManager.Web.App
{
    public class LocalStorage
    {
        private const string AccessTokenKey = "access_token";
        private const string CultureKey = "culture";
        private const string ThemeKey = "theme";

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

        public async Task<string?> GetTheme()
        {
            string? theme = await _storage.ContainKeyAsync(ThemeKey)
                ? await _storage.GetItemAsStringAsync(ThemeKey)
                : null;

            return theme;
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

        public async Task SetTheme(string theme)
        {
            await _storage.SetItemAsStringAsync(ThemeKey, theme);
        }
    }
}
