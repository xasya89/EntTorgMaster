using Microsoft.EntityFrameworkCore;
using EntTorgMaster.Data;

namespace EntTorgMaster.Services
{
    public class ContractorService:IDisposable
    {
        private readonly enttorgsnabContext _db;
        public ContractorService(IDbContextFactory<enttorgsnabContext> dbFactory)
            => _db = dbFactory.CreateDbContext();

        public async Task<List<Contractor>> Get()=>
            await _db.Contractors.OrderBy(c=>c.OrgName).ToListAsync();

        public async Task<List<Contractor>> Get(string s)
        {
            if(string.IsNullOrEmpty(s))
                return await _db.Contractors.ToListAsync();
            return await _db.Contractors.Where(c=>EF.Functions.Like(c.OrgName.ToLower(), $"%{s}%")).OrderBy(c=>c.OrgName).ToListAsync();
        }

        public async Task Add(Contractor contractor)
        {
            await _db.Contractors.AddAsync(contractor);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Contractor contractor)
        {
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var contractor = await _db.Contractors.Where(c => c.Id == id).FirstOrDefaultAsync();
            _db.Contractors.Remove(contractor);
            await _db.SaveChangesAsync();
        }

        public void Dispose()=>
            _db.Dispose();
    }
}
