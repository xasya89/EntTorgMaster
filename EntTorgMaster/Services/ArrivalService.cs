using Microsoft.AspNetCore.Components;
using EntTorgMaster.Data;

namespace EntTorgMaster.Services
{
    public class ArrivalService : IDisposable
    {
        enttorgsnabContext _db;
        public ArrivalService(IDbContextFactory<enttorgsnabContext> dbContextFactory) =>
            _db = dbContextFactory.CreateDbContext();

        public async Task Add(Arrival model)
        {
            model.ContractorId = model.Contractor.Id;
            model.Contractor = null;
            _db.Arrivals.Add(model);

            foreach (var agood in model.ArrivalGoods)
            {
                agood.Arrival = model;
                agood.GoodId=agood.Good.Id;
                agood.Good = null;
                _db.ArrivalGoods.Add(agood);
            }
            await _db.SaveChangesAsync();
        }
        public void Dispose() => _db.Dispose();
    }
}
