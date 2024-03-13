
namespace OnlineStoresManager.Abstractions
{
    public class Image
    {
        public required ImageMetadata Metadata { get; set; }
        public required byte[] Data { get; set; }
    }
}
