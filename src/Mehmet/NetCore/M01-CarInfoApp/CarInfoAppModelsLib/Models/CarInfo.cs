using CSD.Util.Repository;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSD.CarInfoApp.Models
{
    public partial class CarInfo : IEntity<int>
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Marka giriniz")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model giriniz")]
        public string Model { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Uygun tarih giriniz")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Motor No giriniz")]
        public string EngineId { get; set; }
    }
}
