using Kancelaria.Models.Cases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Kancelaria.Models
{
    public class Case
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public ICollection<Case> cases { get; set; }

        public List<Participant> participants;
        public Basic basic;
        public Repetytorium repetytorium;
        public MotorClaim motorClaim;


        public int ID { get; set; }
        public string UserId { get; set; }

        public string overlap;

        public bool addParticipant = false;

        [Display(Name = "Data przyjęcia")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",NullDisplayText = "2017/11/11", ApplyFormatInEditMode = true)]
        public DateTime Date { set; get; }

        [Display(Name = "Nazwa sprawy", Prompt = "Nazwa Sprawy")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(50, ErrorMessage = "Nazwa sprawy nie może mieć więcej niż 50 znaków.")]      
        public string Name { get; set; }

        [Display(Name = "Pełnomocnik")]
        [StringLength(30, ErrorMessage = "Nazwa pełnomocnika jest zbyt długa.")]
        public string Pelnomocnik { get; set; }

        public bool Ended { get; set; }
    }
}
