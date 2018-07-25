using AG.Data;
using AG.Data.Model;
using Bogus;
using System;
using System.Linq;

namespace AG.SeedData
{
    public static class Seed
    {
        public static void SeedContext(AgContext context)
        {
            context.Database.EnsureCreated();

            SeedSettings(context);
            SeedCourses(context);
            SeedHoles(context);
            SeedCourseInfo(context);

            context.SaveChanges();
        }

        private static void SeedSettings(AgContext context)
        {
            context.Settings.Add(new Setting { Key = "CourseImageUrl", Value = "https://images.com/" });
            context.SaveChanges();
        }

        private static void SeedCourses(AgContext context)
        {
            var fakeCourse = new Faker<Course>()
                                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                                .RuleFor(c => c.ImagePath, f => f.Internet.Url());

            for (int i = 1; i <= 5; i++)
            {
                var course = fakeCourse.Generate();

                context.Courses.Add(course);
            }

            context.SaveChanges();
        }

        private static void SeedCourseInfo(AgContext context)
        {
            var fakeCourseAddress = new Faker<CourseAddress>()
                                        .RuleFor(a => a.Street, f => f.Address.StreetAddress())
                                        .RuleFor(a => a.City, f => f.Address.City())
                                        .RuleFor(a => a.State, f => f.Address.StateAbbr())
                                        .RuleFor(a => a.Zip, f => f.Address.ZipCode("#####"));

            var fakeCourseContactInfo = new Faker<CourseContactInfo>()
                                        .RuleFor(a => a.Website, f => f.Internet.Url())
                                        .RuleFor(a => a.ContactEmail, f => f.Internet.Email())
                                        .RuleFor(a => a.ContactPhone, f => f.Phone.PhoneNumber());

            var fakeCourseText = new Faker<CourseTextContent>()
                            .RuleFor(a => a.About, f => f.Lorem.Paragraph());

            foreach (var course in context.Courses)
            {
                var address = fakeCourseAddress.Generate();
                address.CourseId = course.Id;

                var contactInfo = fakeCourseContactInfo.Generate();
                contactInfo.CourseId = course.Id;

                var text = fakeCourseText.Generate();
                text.CourseId = course.Id;

                context.CourseAddresses.Add(address);
                context.CourseContactInfo.Add(contactInfo);
                context.CourseTexts.Add(text);
            }

            context.SaveChanges();
        }

        private static void SeedHoles(AgContext context)
        {
            var fakeHole = new Faker<Hole>()
                                        .RuleFor(a => a.Par, f => new Random().Next(1, 6))
                                        .RuleFor(a => a.WistiaKey, f => f.Random.AlphaNumeric(15));

            foreach (var course in context.Courses)
            {
                foreach (var i in Enumerable.Range(1, 18))
                {
                    var hole = fakeHole.Generate();
                    hole.CourseId = course.Id;
                    hole.Number = i;

                    context.Holes.Add(hole);
                }
            }

            context.SaveChanges();
        }
    }
}
