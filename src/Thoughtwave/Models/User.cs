using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Thoughtwave.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SignUpDate { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public bool IsBanned { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        public virtual ICollection<Thought> Thoughts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
