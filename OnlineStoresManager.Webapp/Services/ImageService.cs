using OnlineStoresManager.Abstractions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Services
{
    public class ImageService : ServiceClient
    {
        public ImageService(HttpClient client, JsonSerializerOptions jsonOptions) : base(client, jsonOptions)
        {
        }

        public async Task<string?> Upload(Image image)
        {
            var response = await PostAsJsonAsync("upload", image);
            var imageFullPath = await ReadAsStringAsync(response);
            return imageFullPath;
        }

        public async Task Delete(ImageMetadata imageMetadata)
        {
            await PostAsJsonAsync("delete", imageMetadata);
        }

    }
}
