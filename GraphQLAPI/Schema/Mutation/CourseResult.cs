using GraphQLAPI.Schema.Query;

namespace GraphQLAPI.Schema.Mutation
{
    public class CourseResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subjects Subject { get; set; }
        public int InstructorId { get; set; }
    }
}
