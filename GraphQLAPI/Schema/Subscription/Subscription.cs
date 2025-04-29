using GraphQLAPI.Schema.Mutation;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLAPI.Schema.Subscription
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<CourseResult>> CourseUpdated(int id,[EventMessage] CourseResult course, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string send = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";

            return await topicEventReceiver.SubscribeAsync<CourseResult>(send);

        }
    }
}
