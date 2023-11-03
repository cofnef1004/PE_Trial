using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class AddRequest
    {
        public string FullName { get; set; } = null!;

        public bool Male { get; set; }

        public string Dob { get; set; }

        public string Nationality { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
