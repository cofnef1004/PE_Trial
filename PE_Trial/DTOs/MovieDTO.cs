
using PE_Trial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseYear { get; set; }

        public string? Description { get; set; }

        public string Language { get; set; } = null!;

        public int? ProducerId { get; set; }

        public int? DirectorId { get; set; }

        public string ProducerName { get; set; }

        public string DirectorName { get; set; }

        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public virtual ICollection<Star> Stars { get; set; } = new List<Star>();
    }
}
