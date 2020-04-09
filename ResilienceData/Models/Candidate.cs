using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Models
{
    public class Candidate:BaseModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public int Role { get; set; }
        public int TeamId { get; set; }
        public int OrganisationId { get; set; }
    

    }
}
