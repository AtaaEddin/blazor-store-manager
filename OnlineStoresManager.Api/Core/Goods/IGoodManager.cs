using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.API.Goods
{
    public interface IGoodManager
    {
        Task<BasicGood> Create(BasicGood good);
        Task<BasicGood?> DeleteGood(Guid id);
        Task<IPage<BasicGood>> Find(IBasicGoodFilter filter);
        Task<BasicGood?> GetGood(Guid id);
        Task<BasicGood> Update(BasicGood good);
    }
}
