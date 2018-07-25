using AG.Data.Model;
using AG.Dto;

namespace AG.Service.Extensions
{
    internal static class ModelExtensions
    {
        public static CourseDto ToDto(this Course model)
        {
            var dto = new CourseDto();
            dto.Id = model.Id == 0 ? (long?)null : model.Id;
            dto.Name = model.Name;
            dto.ImagePath = model.ImagePath;

            return dto;
        }

        public static HoleDto ToDto(this Hole model)
        {
            var dto = new HoleDto();
            dto.Id = model.Id == 0 ? (long?)null : model.Id;
            dto.CourseId = model.CourseId;
            dto.Number = model.Number;
            dto.Par = model.Par;
            dto.WistiaKey = model.WistiaKey;

            return dto;
        }

        public static CourseInfoDto ToCourseInfoDto(this (CourseAddress address, CourseContactInfo info, CourseTextContent text) model)
        {
            var dto = new CourseInfoDto();

            if(model.address != null)
            {
                dto.CourseId = model.address.CourseId;
                dto.AddressInfo = new CourseInfoDto.CourseAddressDto();
                dto.AddressInfo.Street = model.address.Street;
                dto.AddressInfo.City = model.address.City;
                dto.AddressInfo.State = model.address.State;
                dto.AddressInfo.Zip = model.address.Zip;
            }

            if(model.info != null)
            {
                dto.CourseId = model.info.CourseId;
                dto.ContactInfo = new CourseInfoDto.CourseContactInfoDto();
                dto.ContactInfo.Website = model.info.Website;
                dto.ContactInfo.ContactEmail = model.info.ContactEmail;
                dto.ContactInfo.ContactPhone = model.info.ContactPhone;
            }

            if (model.text != null)
            {
                dto.CourseId = model.text.CourseId;
                dto.TextContent = new CourseInfoDto.CourseTextDto();
                dto.TextContent.About = model.text.About;
            }

            return dto;
        }
    }
}
