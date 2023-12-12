namespace OnlineStoresManager.Abstractions
{
    public class FileExportRequest<TEntity, TFilter>
    {
        public FileExportConfiguration<TEntity> Configuration { get; }
        public TFilter Filter { get; }

        public FileExportRequest(FileExportConfiguration<TEntity> configuration, TFilter filter)
        {
            Configuration = configuration;
            Filter = filter;
        }
    }
}
