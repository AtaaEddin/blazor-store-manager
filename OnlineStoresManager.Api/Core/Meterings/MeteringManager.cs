
namespace OnlineStoresManager.API
{
    internal class MeteringManager : IMeteringManager
    {
        private readonly MeteringPointStore _pointStore;

        public MeteringManager(MeteringPointStore pointStore)
        {
            _pointStore = pointStore;
        }

        public async Task<MeteringPoint> Create(MeteringPoint point)
        {
            await _pointStore.Create(point);

            return point;
        }

        public async Task<MeteringPoint?> DeletePoint(Guid id)
        {
            MeteringPoint? point = await _pointStore.Get(id);
            if (point != null)
            {
                await _pointStore.Delete(point);
            }

            return point;
        }

        public async Task<IPage<MeteringPoint>> Find(IMeteringPointFilter filter)
        {
            IReadOnlyCollection<MeteringPoint> points = await _pointStore.Find(filter);
            int totalCount = await _pointStore.GetTotalCount(filter);

            return new PagedList<MeteringPoint>(points, totalCount);
        }

        public Task<MeteringPoint?> GetPoint(Guid id)
        {
            return _pointStore.Get(id);
        }

        public async Task<MeteringPoint> Update(MeteringPoint point)
        {
            await _pointStore.Update(point);

            return point;
        }
    }
}
