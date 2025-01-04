using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentCatalog.Shared.Models
{
    public class ItemDetails
    {
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; }
        public string ReleaseDate { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; } = string.Empty ;
        public string Director { get; set; } = string.Empty;
        public string Actors { get; set; } = string.Empty;
        public string Plot { get; set; } = string.Empty;
        public string Awards { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
        public string imdbRating { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

    }
}
