namespace SwimmingTool.Domain
{
    public class Swimmer : Entity<int>
    {
        private Swimmer(string name, string category)
        {
            Name = name;
            Category = category;
        }
        public static Swimmer CreateSwimmer(string name, string category)
        {
            return new Swimmer(name, category);
        }

        public string Name { get; private set; }
        public string Category { get; private set; }
    }
}