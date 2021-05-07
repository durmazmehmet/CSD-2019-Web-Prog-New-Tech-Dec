using System;
using System.ComponentModel.DataAnnotations;

// Client olacak sistem elbetteki modeli bilmek durumunda
namespace CSD.ParticipansAppRestClientService.Models
{
    public class ParticipantModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool IsParticipate { get; set; }
    }
}
