using AutoMapper;
using EntTorgMaster.Data;
using EntTorgMaster.Models;

namespace EntTorgMaster.Mappings
{
    public class MappingOrder:Profile
    {
        public MappingOrder()
        {
            CreateMap<OrderModel, Order>();
        }
    }
}
