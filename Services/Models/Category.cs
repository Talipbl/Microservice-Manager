namespace Services
{
    public class Category
    {
        public string Name { get; set; }
        public List<Microservice> Services { get; set; } = new List<Microservice>();

        public override string ToString()
        {
            return Name;
        }
    }
}
