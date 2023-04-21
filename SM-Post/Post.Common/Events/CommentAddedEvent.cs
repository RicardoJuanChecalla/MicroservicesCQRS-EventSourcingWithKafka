using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommentAddedEvent : BaseEvent
    {
        public CommentAddedEvent() : base(nameof(CommentAddedEvent))
        {
        }
        public Guid CommetId { get; set; }
        public string? Commet { get; set; }
        public string? UserName { get; set; }
        public DateTime CommentDate { get; set; }
    }
}