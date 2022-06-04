namespace EntTorgMaster.Services
{
    public class UserService:IDisposable
    {
        private readonly enttorgsnabContext _db;
        public UserService(IDbContextFactory<enttorgsnabContext> dbFactory)
            => _db = dbFactory.CreateDbContext();

        public async Task<IEnumerable<User>> GetUsers() => await _db.Users.OrderBy(u=>u.Name).ToListAsync();

        public async Task AddUser(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUser(int id, User user)
        {
            var u=await _db.Users.SingleOrDefaultAsync(x => x.Id == id);
            if(u!=null)
            {
                u.Name = user.Name.Trim();
                u.Password = user.Password.Trim();
                u.Role = user.Role;
            }
        }

        public async Task RemoveUser(int id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public void Dispose() => _db.Dispose();
    }
}
