using OnlineStoresManager.Abstractions;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.API.Goods
{
    public class GoodManager : IGoodManager
    {
        private readonly GoodStore _store;

        public GoodManager(GoodStore store)
        {
            _store = store;
        }

        public async Task<BasicGood> Create(BasicGood good)
        {
            await _store.Create(good);
            return good;
        }

        public async Task<BasicGood?> DeleteGood(Guid id)
        {
            var good = await _store.Get(id);
            if(good != null) 
            {
                await _store.Delete(good);
            }
            
            return good;
        }

        public async Task<IPage<BasicGood>> Find(IBasicGoodFilter filter)
        {
            IReadOnlyCollection<BasicGood> goods = await _store.Find(filter);
            int totalCount = await _store.GetTotalCount(filter);

            return new PagedList<BasicGood>(goods, totalCount);
        }

        public async Task<BasicGood?> GetGood(Guid id)
        {
            return await _store.Get(id);
        }

        public async Task<BasicGood> Update(BasicGood good)
        {
            await _store.Update(good);

            return good;
        }
    }
}
