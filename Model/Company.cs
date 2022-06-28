namespace Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Course> Courses { get; } = new List<Course>();
        public override string ToString()
        {
            return "Company \"" + Name + "\"";
        }
    }
}
