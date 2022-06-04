namespace EntTorgMaster.Services
{
    public class GoodService:IDisposable
    {
        private readonly enttorgsnabContext _db;
        public GoodService(IDbContextFactory<enttorgsnabContext> dbFactory)
            => _db = dbFactory.CreateDbContext();

        public async Task<List<Good>> GetGoods() => await _db.Goods.OrderBy(g => g.Name).ToListAsync();

        public async Task<Good> GetGood(int id) => await _db.Goods.FindAsync(id);

        public async Task AddGood(Good good)
        {
            await _db.Goods.AddAsync(good);
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
