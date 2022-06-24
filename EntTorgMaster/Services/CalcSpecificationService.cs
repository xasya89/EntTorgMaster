using EntTorgMaster.Models;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EntTorgMaster.Services
{
    public class CalcSpecificationService
    {
        private Dictionary<int, List<SettingWriteofModel>> settingDict;
        private IDbContextFactory<enttorgsnabContext> _dbFactory;

        public CalcSpecificationService(IDbContextFactory<enttorgsnabContext> dbFactory)
        {
            _dbFactory = dbFactory;
            LoadParams();
        } 

        public async Task LoadParams()
        {

            if (File.Exists("seetingswriteof.json"))
                using (StreamReader sr = new StreamReader("seetingswriteof.json"))
                {
                    string settingsstr = await sr.ReadToEndAsync();
                    settingDict = JsonSerializer.Deserialize<Dictionary<int, List<SettingWriteofModel>>>(settingsstr);
                }
            else
            {
                using var db = _dbFactory.CreateDbContext();
                settingDict = new();
                foreach (var doortype in await db.DoorTypes.AsNoTracking().ToListAsync())
                    settingDict.Add(doortype.Id, new());
            }
        }

        public void Calc(OrderDoor door)
        {
            door.DoorSpecificationsWriteof.Clear();
            if(settingDict.TryGetValue(door.DoorTypeId, out var settings))
                foreach(var setting in settings)
                {
                    decimal countWriteOf = 0;
                    switch (setting.TypeCalc)
                    {
                        case SettingWriteofTypeCalc.Square:
                            countWriteOf = door.H * door.W * (setting.CalcSquare.DoubleCount ? 2 : 1) * setting.CalcSquare.Count * 0.000001M;
                            break;
                        case SettingWriteofTypeCalc.Around:
                            countWriteOf = (door.H + door.W) * 2 * setting.CalcAround.Count;
                            break;
                        case SettingWriteofTypeCalc.Counter:
                            countWriteOf = setting.CalcUnit.Count;
                            break;
                    }
                    door.DoorSpecificationsWriteof.Add(new DoorSpecificationWriteof
                    {
                        OrderDoor = door,
                        GoodType = setting.GoodType,
                        Count = countWriteOf
                    });
                }
            
        }
    }
}
