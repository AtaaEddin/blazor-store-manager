using System.Collections.Generic;

namespace OnlineStoresManager.Abstractions
{
    public class FileExportConfiguration<TEntity>
    {
        public FileType FileType { get; }
        public List<FileExportProperty<TEntity>> Properties { get; }

        public FileExportConfiguration(FileType fileType, List<FileExportProperty<TEntity>> properties)
        {
            FileType = fileType;
            Properties = properties;
        }
    }
}
