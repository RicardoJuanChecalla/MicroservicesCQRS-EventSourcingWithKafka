using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class MessageUpatedEvent : BaseEvent
    {
        public MessageUpatedEvent() : base(nameof(MessageUpatedEvent))
        {
        }
        public string? Message { get; set; }
    }
}