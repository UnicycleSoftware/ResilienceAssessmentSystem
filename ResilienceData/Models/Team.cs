using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Models
{
    public class Team:BaseModel
    {
        public int OrganisationId { get; set; }
        public string TeamName { get; set; }
        
    }
}
