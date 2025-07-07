using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTO.Car;
using Backend.DTO.Order;
using Backend.DTO.Payment;
using Backend.DTO.User;

namespace Backend.Mappings
{
    // AutoMappersProfile.cs

    public class AutoMappersProfile : Profile
    {
        public AutoMappersProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderAddOn, OrderAddOnDTO>().ReverseMap();
           // CreateMap<ServicePackage, ServicePackageDTO>();
            // ✅ Explicit mapping for UserDTO -> ApplicationUser
            CreateMap<UserDTO, ApplicationUser>().ReverseMap(); 


            CreateMap<Order, UpdateOrderStatusDTO>().ReverseMap();
            CreateMap<PaymentReceipt, PaymentReceiptDTO>().ReverseMap();
            CreateMap<PromoCode, PromoCodeDTO>().ReverseMap();
            CreateMap<AddOn, OrderAddOnDTO>()
             .ForMember(dest => dest.AddOnId, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.AddOnName, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.AddOnPrice, opt => opt.MapFrom(src => src.Price))
             .ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();


        }
    }
}
