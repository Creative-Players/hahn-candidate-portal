using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Entities
{
    public class JobOption
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
