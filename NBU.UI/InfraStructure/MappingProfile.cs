using AutoMapper;
using NBU.DAL.Entities;
using NBU.DAL.ViewModel;

namespace NBU.UI.InfraStructure
{
    public class MappingProfile:Profile
    {
        // Mapping between Model And View Model
        // Code **** CreateMap<ModelVM, Model>().ReverseMap(); 
        // To Map Custome Property Use This Code
        // .ForMember(dest => dest.Id,opts => opts.MapFrom(src => src.Id))
        // dest For Model , src For VM
        public MappingProfile()
        {
            //CreateMap<GenderVM, Gender>()
            //    .ForMember(
            //    dest => dest.Id,opts => opts.MapFrom(src => src.Id))
            //    .ForMember(
            //    dest => dest.NameEn, opts => opts.MapFrom(src => src.NameEn))
            //    .ForMember(
            //    dest => dest.NameAr, opts => opts.MapFrom(src => src.NameAr))
            //    .ForMember(
            //    dest => dest.CreateOn, opts => opts.MapFrom(src => src.CreateOn))
            //    .ForMember(
            //    dest => dest.UpdateOn, opts => opts.MapFrom(src => src.UpdateOn));


            CreateMap<GenderVM, Gender>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<EmployeeCertificationVM, EmployeeCertification>().ReverseMap();


        }
    }
}
