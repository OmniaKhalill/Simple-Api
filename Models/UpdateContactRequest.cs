using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Models
{
    public class UpdateContactRequest
    {
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; } 
        public string Address { get; set; }
    }
}
    
