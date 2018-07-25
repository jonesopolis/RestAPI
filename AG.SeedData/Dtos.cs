using AG.Dto;
using System.Collections.Generic;

namespace AG.Api.Tests
{
    public static class Dtos
    {
        static Dtos()
        {
            SettingsDto = new SettingsDto
            {
                CourseImageUrl = "https://images.com"
            };

            CourseDto = new CourseDto
            {
                Id = Faker.RandomNumber.Next(1, 9999),
                Name = Faker.Company.Name(),
                ImagePath = Faker.Internet.DomainName()
            };

            CourseInfoDto = new CourseInfoDto
            {
                AddressInfo = new CourseInfoDto.CourseAddressDto
                {
                    Street = Faker.Address.StreetAddress(),
                    City = Faker.Address.City(),
                    State = Faker.Address.UsStateAbbr(),
                    Zip = Faker.Address.ZipCode()
                },
                ContactInfo = new CourseInfoDto.CourseContactInfoDto
                {
                    Website = Faker.Internet.DomainName(),
                    ContactEmail = Faker.Internet.Email(),
                    ContactPhone = Faker.Phone.Number()
                },
                TextContent = new CourseInfoDto.CourseTextDto
                {
                    About = Faker.Company.BS()
                }
            };

            HoleDtoList = new List<HoleDto>
            {
                new HoleDto
                {
                    Id = Faker.RandomNumber.Next(1,9999),
                    CourseId = CourseDto.Id.Value,
                    Par = Faker.RandomNumber.Next(1, 5),
                    Number = 1
                },
                new HoleDto
                {
                    Id = 51,
                    CourseId = CourseDto.Id.Value,
                    Par = Faker.RandomNumber.Next(1, 5),
                    Number = 2
                },
            };
        }

        public static SettingsDto SettingsDto { get; }
        public static CourseDto CourseDto { get; }
        public static CourseInfoDto CourseInfoDto { get; }
        public static List<HoleDto> HoleDtoList { get; }
    }
}
