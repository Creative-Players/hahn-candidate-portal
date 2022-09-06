using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Entities
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public int JobOptionId { get; set; }
        [ValidateNever]
        public JobOption JobOptionName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
