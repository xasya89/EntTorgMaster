namespace EntTorgMaster.Data
{
    public class DoorTypesRepository : IDisposable
    {
        enttorgsnabContext _db;
        public DoorTypesRepository(enttorgsnabContext db) => _db = db;

        public async Task<IEnumerable<DoorType>> GetDoorTypes() => await _db.DoorTypes.ToListAsync();
        public void Dispose()=>
            _db.Dispose();
    }
}
