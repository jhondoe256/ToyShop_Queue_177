namespace ToyShop.Data
{
    public class Toy
    {
        public Toy(){}
        public Toy(string name, string description, ToyType toyType ,decimal price)
        {
            Name = name;
            Description = description;
            ToyType = toyType;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ToyType ToyType { get; set; }
        public decimal Price {get;set;}
        
        public override string ToString()
        {
            string str = $"Id: {Id}\n"+
                         $"Name: {Name}\n"+
                         $"Description: {Description}\n"+
                         $"Price: ${Price}\n";
            return str;
        }
    }
}