
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class DirectorDto2
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Gender { get; set; }

        public DateTime Dob { get; set; }

        public string DobString { get; set; }

        public string Nationality { get; set; } = null!;

        public string Description { get; set; } = null!;

        public virtual ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
    }
}
