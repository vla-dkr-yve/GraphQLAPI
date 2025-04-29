using GraphQLAPI.Schema.Query;

namespace GraphQLAPI.Schema.Mutation
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subjects Subject { get; set; }
        public int InstructorId { get; set; }
    }
}
