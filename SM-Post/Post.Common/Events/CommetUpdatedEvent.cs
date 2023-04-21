using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommetUpdatedEvent: BaseEvent
    {
        public CommetUpdatedEvent() : base(nameof(CommetUpdatedEvent))
        {
        }
        public Guid CommetId { get; set; }
        public string? Commet { get; set; }
        public string? UserName { get; set; }
        public DateTime EditDate { get; set; }
    }
}