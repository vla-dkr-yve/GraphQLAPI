using GraphQLAPI.Schema.Query;
using HotChocolate.Subscriptions;
using GraphQLAPI.Schema.Subscription;

namespace GraphQLAPI.Schema.Mutation
{
    public class Mutation
    {
        public List<CourseResult> _courses;

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public async Task<CourseResult> CreateCourse(CourseInputType CourseInputType, [Service] ITopicEventSender topicEventSender)
        {
            var res = new CourseResult
            {
                Name = CourseInputType.Name,
                Subject = CourseInputType.Subject,
                InstructorId = CourseInputType.InstructorId
            };
            

            _courses.Add(res);

            await topicEventSender.SendAsync<CourseResult>(nameof(Subscription.Subscription.CourseCreated), res);

            return res;
        }
        public CourseResult UpdateCourse(int Id,CourseInputType CourseInputType, [Service] ITopicEventSender topicEventSender)
        {
            var course = _courses.FirstOrDefault(c => c.Id == Id);

            if (course is null)
            {
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));
            }

            course.Name = CourseInputType.Name;
            course.Subject = CourseInputType.Subject;
            course.InstructorId = CourseInputType.InstructorId;

            _courses.Add(course);

            string send = $"{course.Id}_{nameof(Subscription.Subscription.CourseUpdated)}";
            topicEventSender.SendAsync<CourseResult>(send, course);

            return course;
        }

        public bool DeleteCourse(int Id)
        {
            return _courses.RemoveAll(c => c.Id == Id) >= 1;
        }
    }
}
