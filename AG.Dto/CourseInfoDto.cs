namespace AG.Dto
{
    public class CourseInfoDto
    {
        public long CourseId { get; set; }
        public CourseAddressDto AddressInfo { get; set; }
        public CourseContactInfoDto ContactInfo { get; set; }
        public CourseTextDto TextContent {get;set;}


        public class CourseAddressDto
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
        }

        public class CourseContactInfoDto
        {
            public string Website { get; set; }
            public string ContactEmail { get; set; }
            public string ContactPhone { get; set; }
        }

        public class CourseTextDto
        {
            public string About { get; set; }
        }
    }
}
