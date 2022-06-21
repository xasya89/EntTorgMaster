using Microsoft.EntityFrameworkCore;
namespace EntTorgMaster.Services
{
    public class GoodService:IDisposable
    {
        private readonly enttorgsnabContext _db;
        public GoodService(IDbContextFactory<enttorgsnabContext> dbFactory)
            => _db = dbFactory.CreateDbContext();

        public async Task<List<Good>> GetGoods() => await _db.Goods.Include(g=>g.GoodBalance).OrderBy(g => g.Name).ToListAsync();
        public async Task<List<Good>> GetGoods(string name) =>
            await _db.Goods.Include(g => g.GoodBalance).Where(g => EF.Functions.Like(g.Name, $"%{name}%")).ToListAsync();

        public async Task<List<Good>> GetGoods(string name, GoodType goodType) =>
            await _db.Goods.Include(g => g.GoodBalance).Where(g => EF.Functions.Like(g.Name, $"%{name}%") & g.Type==goodType).ToListAsync();

        public async Task<Good> GetGood(int id) => 
            await _db.Goods.Include(g => g.GoodBalance).Where(g=>g.Id==id).FirstOrDefaultAsync();

        public async Task AddGood(Good good)
        {
            await _db.Goods.AddAsync(good);
            await _db.GoodBalances.AddAsync(new GoodBalance { Good = good, Count=0, Price=0 });
            await _db.SaveChangesAsync();
        }

        public async Task EditGood(Good good)
        {
            await _db.SaveChangesAsync();
        }
        public async Task RemoveGood(int id)
        {
            var good=await _db.Goods.FindAsync(id);
            if(good!=null)
            {
                _db.Goods.Remove(good);
                await _db.SaveChangesAsync();
            }
        }
        public void Dispose() => _db.Dispose();
    }
}
