namespace EntTorgMaster.Data
{
    public class DoorTypesRepository : IDisposable
    {
        enttorgsnabContext _db;
        public DoorTypesRepository(enttorgsnabContext db) => _db = db;

        public async Task<IEnumerable<DoorType>> GetDoorTypesAsync() 
            => await _db.DoorTypes.OrderBy(d=>d.Name).ToListAsync();

        public async Task DeleteTypeDoorAsync(DoorType doorType)
        {
            _db.DoorTypes.Remove(await _db.DoorTypes.Where(d=>d.Id==doorType.Id).FirstOrDefaultAsync());
            await _db.SaveChangesAsync();
        }
        public async Task<DoorType> AddDoorTypeAsync(string name)
        {
            if (name == String.Empty)
                return new();
            var doortype = new DoorType { Name = name };
            _db.DoorTypes.Add(doortype);
            await _db.SaveChangesAsync();
            return doortype;
        }

        public async Task EditDoorTypeAsync(DoorType doorType)
        {
            _db.SaveChangesAsync();
        }

        public void Dispose()=>
            _db.Dispose();
    }
}
