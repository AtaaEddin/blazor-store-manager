namespace OnlineStoresManager.API
{
    public class MeteringPointStore
    {
        private readonly PriceDbContext _dbContext;

        public MeteringPointStore(PriceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Create(MeteringPoint point)
        {
            _dbContext.MeteringPoints.Add(point);

            return _dbContext.SaveChangesAsync();
        }

        public Task<int> Delete(MeteringPoint point)
        {
            _dbContext.MeteringPoints.Remove(point);

            return _dbContext.SaveChangesAsync();
        }

        public Task<List<MeteringPoint>> Find(IMeteringPointFilter filter)
        {
            return _dbContext.MeteringPoints
                .FilterBy(filter)
                .SortBy(filter)
                .TakePage(filter)
                .ToListAsync();
        }

        public Task<MeteringPoint?> Get(Guid id)
        {
            return _dbContext.MeteringPoints.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> GetTotalCount(IMeteringPointFilter filter)
        {
            return _dbContext.MeteringPoints
                .FilterBy(filter)
                .CountAsync();
        }

        public Task<int> Update(MeteringPoint point)
        {
            _dbContext.MeteringPoints.Update(point);

            return _dbContext.SaveChangesAsync();
        }
    }
}
