using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kancelaria.Models
{
    public class Notification : ICloneable
    {
        public ICollection<Notification> notifications { get; set; }
        public List<Notification> currentNotifications = new List<Notification>();
        public int ID { get; set; }

        [JsonProperty(PropertyName = "mail_from")]
        [Display(Name = "Od")]
        public string From { get; set; }

        [Display(Name = "Do")]
        public string To { get; set; }

        [JsonProperty(PropertyName = "mail_title")]
        [Display(Name = "Temat")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "mail_body")]
        [Display(Name = "Wiadomość")]
        public string Body { get; set; }
        public string UserID { get; set; }

        [JsonProperty(PropertyName = "mail_data")]
        [Display(Name = "Data")]
        public string DateCreated { get; set; }

        [Display(Name = "Odczytane")]
        public bool Viewed { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
