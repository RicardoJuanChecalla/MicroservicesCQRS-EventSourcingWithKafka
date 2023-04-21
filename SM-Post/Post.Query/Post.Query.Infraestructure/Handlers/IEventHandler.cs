using Post.Common.Events;

namespace Post.Query.Infraestructure.Handlers
{
    public interface IEventHandler
    {
        Task On(PostCreatedEvent @event);
        Task On(MessageUpatedEvent @event);
        Task On(PostLikedEvent @event);
        Task On(CommentAddedEvent @event);
        Task On(CommetUpdatedEvent @event);
        Task On(CommetRemovedEvent @event);
        Task On(PostRemovedEvent @event);

    }
}