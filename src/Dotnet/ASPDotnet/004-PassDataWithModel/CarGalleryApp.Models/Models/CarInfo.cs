namespace CSD.CarGalleryApp.Models
{
    public class CarInfo
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Plate { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Desc:{Description}, Plate: {Plate}, Price:{Price}";
        }
    }
}