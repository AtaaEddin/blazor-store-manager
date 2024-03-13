using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.API.Core.images
{
    public class ImageService
    {
        private string _imagePath;
        private string _rootPath;
        public ImageService(IWebHostEnvironment webHostEnvironment, UploadImageConfiguration uploadImageConfiguration)
        {
            _imagePath = uploadImageConfiguration.ImagePath ?? @"wwwroot\images";
            _rootPath = Path.Combine(webHostEnvironment.ContentRootPath, _imagePath);
        }

        private string GetFullDirPath(string userName, GoodGategory goodGategory, GoodType goodType)
            => Path.Combine(_rootPath, GetRelativeDirPath(userName, goodGategory, goodType));

        private string GetRelativeDirPath(string userName, GoodGategory goodGategory, GoodType goodType)
            => Path.Combine(_imagePath, userName, goodGategory.ToString(), goodType.ToString());

        private string GetImageName(DateTime imageCreatedAt, string format) 
                                => string.Format("{0}.{1}",
                                    imageCreatedAt.ToString("yyyy-MM-dd HH-mm-ss.fff"),
                                    format ?? "jpg");
        public async Task<string> SaveImage(Image image)
        {
            string fullDirPath = GetFullDirPath(image.Metadata.UserName,
                image.Metadata.Gategory,
                image.Metadata.Type);

            Directory.CreateDirectory(fullDirPath);

            string imageNameWithFormat = GetImageName(image.Metadata.CreatedAt, image.Metadata.Format);

            var fullPathAndImageNameWithExt = Path.Combine(fullDirPath, imageNameWithFormat);

            await File.WriteAllBytesAsync(fullPathAndImageNameWithExt, image.Data);

            return Path.Combine(
                    GetRelativeDirPath(image.Metadata.UserName,
                                        image.Metadata.Gategory,
                                        image.Metadata.Type),
                    imageNameWithFormat); 
        }

        public void DeleteImage(ImageMetadata imageMetadata)
        {
            string fullDirPath = GetFullDirPath(imageMetadata.UserName, imageMetadata.Gategory, imageMetadata.Type);

            string imageNameWithFormat = GetImageName(imageMetadata.CreatedAt, imageMetadata.Format);

            File.Delete(Path.Combine(fullDirPath, imageNameWithFormat));
        }
    }
}
