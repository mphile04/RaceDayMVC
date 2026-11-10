namespace RaceDayMVC.Models
{
    public class EventViewModel
    {
        public int EventID { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    // This matches the API's response structure
    public class EventListResponse
    {
        public int Total { get; set; }
        public List<EventViewModel> Events { get; set; } = new List<EventViewModel>();
    }
}
