using System.Runtime.CompilerServices;

namespace GraphQLAPI.Schema.Query
{
    public class Query
    {
        public IEnumerable<CourseType> GetCourses()
        {
            return new List<CourseType>()
            {
                new CourseType(){
                    Id = 1,
                    Name = "Computer Science",
                    Instructor = new InstructorType()
                    {
                        Id = 1,
                        FirstName = "Vlad",
                        LastName = "Vladi",
                        Salary = 45.55
                    },
                    Subject = Subjects.Mathematics,
                    Students = new List<StudentType>(){
                        new StudentType()
                        {
                            Id = 1,
                            FirstName = "Ban",
                            LastName = "Krue",
                            GPA = 4.0
                        },
                        new StudentType()
                        {
                            Id = 1,
                            FirstName = "Kaen",
                            LastName = "Flue",
                            GPA = 1.0
                        }
                    }
                },
                new CourseType(){
                    Id = 2,
                    Name = "Art",
                    //Instructor = new InstructorType()
                    //{
                    //    Id = 1,
                    //    FirstName = "Ban",
                    //    LastName = "Lof",
                    //    Salary = 11.11
                    //},
                    Subject = Subjects.Mathematics,
                    Students = new List<StudentType>(){
                        new StudentType()
                        {
                            Id = 1,
                            FirstName = "Ear",
                            LastName = "Kanoe",
                            GPA = 5.0
                        },
                        new StudentType()
                        {
                            Id = 1,
                            FirstName = "Kaen",
                            LastName = "Flue",
                            GPA = 4.5
                        }
                    }
                }
            };
        }

        public CourseType GetCourseById(int id)
        {
            return new CourseType()
            {
                Id = id,
                Name = "Computer Science",
                Instructor = new InstructorType()
                {
                    Id = 1,
                    FirstName = "Vlad",
                    LastName = "Vladi",
                    Salary = 45.55
                }
            };
        }

        [GraphQLDeprecated("This query is outdated")]
        public string Instructions => "Hello world";
    }
}
