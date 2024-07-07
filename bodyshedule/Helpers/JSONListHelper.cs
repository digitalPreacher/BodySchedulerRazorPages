using Humanizer;

namespace bodyshedule.Helpers
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(List<Models.Event> events)
        {
            var eventList = new List<Event>();

            foreach (var modelEvent in events)
            {
                var myEvent = new Event()
                {
                    id = modelEvent.Id,
                    title = modelEvent.Name,
                    description = modelEvent.Description,
                    start = modelEvent.StartTime,
                    end = modelEvent.EndTime,
                    display = "block"
                };
                eventList.Add(myEvent);
            }

            return System.Text.Json.JsonSerializer.Serialize(eventList);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTimeOffset start { get; set; }
        public DateTimeOffset end { get; set; }

        public string display { get; set; }

    }

}
