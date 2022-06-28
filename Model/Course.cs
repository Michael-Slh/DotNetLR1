using System;

namespace Model
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string? Name { get; init; }
        public BusStop FirstStop { get; init; }
        public BusStop LastStop { get; init; }
        public double Duration { get; init; }
        public int BusAmount => Buses.Count;
        public Company? Company { get; init; }
        public IEnumerable<string?> BusNumbers => Buses.Select(x => x.Number);
        public List<Bus> Buses { get; } = new List<Bus>();
    }
}
