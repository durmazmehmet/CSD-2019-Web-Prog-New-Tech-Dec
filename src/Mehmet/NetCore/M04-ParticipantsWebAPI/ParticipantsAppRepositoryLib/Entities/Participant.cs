using CSD.Util.Repository;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSD.ParticipantsApp.Repository.Entities
{
    public partial class Participant : IEntity<string>
    {
        [Required(ErrorMessage = "Please provide your email")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsParticipate { get; set; }
    }
}
