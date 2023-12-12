using mudblazor.Abstractions;

namespace OnlineStoresManager.API
{
    public interface IMeteringManager
    {
        Task<MeteringPoint> Create(MeteringPoint point);
        Task<MeteringPoint?> DeletePoint(Guid id);
        Task<IPage<MeteringPoint>> Find(IMeteringPointFilter filter);
        Task<MeteringPoint?> GetPoint(Guid id);
        Task<MeteringPoint> Update(MeteringPoint point);
    }
}
