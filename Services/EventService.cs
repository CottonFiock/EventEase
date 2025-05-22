using System.Collections.Generic;

namespace EventEase.Data
{
    public class EventService
    {
        private readonly List<Event> _events = new();

        public IReadOnlyList<Event> Events => _events.AsReadOnly();

        private int _nextId = 1;

        public void AddEvent(Event newEvent)
        {
            newEvent.Id = _nextId++;
            _events.Add(newEvent);
        }

        public void RegisterAttendance(int eventId, string userEmail)
        {
            var ev = _events.Find(e => e.Id == eventId);
            if (ev != null && !ev.Attendees.Contains(userEmail))
            {
                ev.Attendees.Add(userEmail);
            }
        }
    }
}