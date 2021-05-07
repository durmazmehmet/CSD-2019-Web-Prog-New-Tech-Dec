namespace FormdanModele.Model.Entity
{
    public class Product
    {
        public string Name { get; set; }
        public uint Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Cost { get; set; }
        public override string ToString()
        {
            return $"{Name}[{Stock}]: {Cost}";
        }
        public decimal Total => UnitPrice * Stock;
    }
}
