using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Models
{
    public class CandidateModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string CountryOfOrigin { get; set; }
        public string Email { get; set; }

        public int JobOptionId { get; set; }
        public string JobOptionName { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
