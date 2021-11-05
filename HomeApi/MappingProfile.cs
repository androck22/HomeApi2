using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts.Models.Devices;
using HomeApi.Contracts.Models.Home;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;

namespace HomeApi
{
    /// <summary>
    /// Настройки маппинга всех сущностей приложения
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));

            // Валидация запросов:
            CreateMap<AddDeviceRequest, Device>()
                .ForMember(d => d.Location,
                    opt => opt.MapFrom(r => r.RoomLocation));
            CreateMap<AddRoomRequest, Room>();
            CreateMap<EditRoomRequest, Room>()
                .ForMember(m => m.Name,
                    opt => opt.MapFrom(src => src.NewName))
                .ForMember(m => m.Area,
                    opt => opt.MapFrom(src => src.NewArea))
                .ForMember(m => m.GasConnected,
                    opt => opt.MapFrom(src => src.NewGasConnected))
                .ForMember(m => m.Voltage,
                    opt => opt.MapFrom(src => src.NewVoltage));

            CreateMap<Device, DeviceView>();
            CreateMap<Room, RoomView>();
        }
    }
}