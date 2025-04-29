using GraphQLAPI.Schema.Query;

namespace GraphQLAPI.Schema.Mutation
{
    public class Mutation
    {
        public List<CourseResult> _courses;

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public CourseResult CreateCourse(CourseInputType CourseInputType)
        {
            var res = new CourseResult
            {
                Name = CourseInputType.Name,
                Subject = CourseInputType.Subject,
                InstructorId = CourseInputType.InstructorId
            };
            

            _courses.Add(res);

            return res;
        }

        public CourseResult UpdateCourse(int Id,CourseInputType CourseInputType)
        {
            var res = _courses.FirstOrDefault(c => c.Id == Id);

            if (res is null)
            {
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));
            }

            res.Name = CourseInputType.Name;
            res.Subject = CourseInputType.Subject;
            res.InstructorId = CourseInputType.InstructorId;

            _courses.Add(res);
            return res;
        }

        public bool DeleteCourse(int Id)
        {
            return _courses.RemoveAll(c => c.Id == Id) >= 1;
        }
    }
}
