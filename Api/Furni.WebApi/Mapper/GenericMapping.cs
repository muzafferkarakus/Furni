using AutoMapper;
using Furni.DtoLayer.Dtos.AboutDtos;
using Furni.DtoLayer.Dtos.ContactDtos;
using Furni.DtoLayer.Dtos.FeatureDtos;
using Furni.DtoLayer.Dtos.ProductDtos;
using Furni.DtoLayer.Dtos.ServiceDtos;
using Furni.DtoLayer.Dtos.StaffDtos;
using Furni.DtoLayer.Dtos.SubscribeDtos;
using Furni.DtoLayer.Dtos.TestimonialDtos;
using Furni.EntityLayer.Concrete;

namespace Furni.WebApi.Mapper
{
    public class GenericMapping:Profile
    {
        public GenericMapping()
        {
            CreateMap<CreateAboutDto,About>().ReverseMap();
            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();

            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();

            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();

            CreateMap<CreateStaffDto, Staff>().ReverseMap();
            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<CreateFeatureDto, Feature>().ReverseMap();
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
        }
    }
}
