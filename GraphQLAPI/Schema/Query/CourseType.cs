namespace GraphQLAPI.Schema.Query
{
    public enum Subjects
    {
        Mathematics,
        Chemistry,
        Literature
    }
    public class CourseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public Subjects Subject { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
