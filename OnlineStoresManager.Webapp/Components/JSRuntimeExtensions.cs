using OnlineStoresManager.Abstractions;

using Microsoft.JSInterop;

using System.IO;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp
{
    public static class JSRuntimeExtensions
    {
        public static Task DownloadFile(this IJSRuntime jsRuntime, FileBytes file)
        {
            return jsRuntime.DownloadFile(file.Name, file.Bytes);
        }

        public static async Task DownloadFile(this IJSRuntime jsRuntime, string fileName, byte[] fileBytes)
        {
            using (DotNetStreamReference fileStreamRef = new DotNetStreamReference(new MemoryStream(fileBytes)))
            {
                await jsRuntime.InvokeVoidAsync("downloadFileFromStream", fileName, fileStreamRef);
            }
        }
    }
}
