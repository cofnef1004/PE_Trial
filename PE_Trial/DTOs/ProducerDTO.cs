
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProducerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
    }
}
