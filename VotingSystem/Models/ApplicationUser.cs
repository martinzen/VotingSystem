using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string VoterId { get; set; }
        [Required]
        public string VoterName { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
