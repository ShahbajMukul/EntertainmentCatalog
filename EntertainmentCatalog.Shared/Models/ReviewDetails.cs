using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentCatalog.Shared.Models
{
    public class ReviewDetails : ItemDetails
    {
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public string ReviewText { get; set; } = string.Empty;
        public bool WillWatchAgain { get; set; } = false;
    }
}
