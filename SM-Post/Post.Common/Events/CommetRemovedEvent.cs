using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommetRemovedEvent: BaseEvent
    {
        public CommetRemovedEvent() : base(nameof(CommetRemovedEvent))
        {
        }
        public Guid CommetId { get; set; }
        public string? UserName { get; set; }
   
    }
}