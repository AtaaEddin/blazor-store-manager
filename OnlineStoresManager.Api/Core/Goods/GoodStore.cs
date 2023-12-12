using Microsoft.EntityFrameworkCore;
using OnlineStoresManager.API.Db;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.API.Goods
{
    internal class GoodStore
    {
        private readonly AppDbContext _dbContext;

        public GoodStore(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Create(BasicGood good)
        {
            _dbContext.Goods.Add(good);

            return _dbContext.SaveChangesAsync();
        }

        public Task<int> Delete(BasicGood good)
        {
            _dbContext.Goods.Remove(good);

            return _dbContext.SaveChangesAsync();
        }

        public Task<List<BasicGood>> Find(IBasicGoodFilter filter)
        {
            return _dbContext.Goods
                .FilterBy(filter)
                .SortBy(filter)
                .TakePage(filter)
                .ToListAsync();
        }

        public Task<BasicGood?> Get(Guid id)
        {
            return _dbContext.Goods.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> GetTotalCount(IBasicGoodFilter filter)
        {
            return _dbContext.Goods
                .FilterBy(filter)
                .CountAsync();
        }

        public Task<int> Update(BasicGood good)
        {
            _dbContext.Goods.Update(good);

            return _dbContext.SaveChangesAsync();
        }
    }
}
}
