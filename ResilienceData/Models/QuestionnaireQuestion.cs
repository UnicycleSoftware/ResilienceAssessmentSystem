using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Models
{
    public class QuestionnaireQuestion:BaseModel
    {
        public int QuestionnaireId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }

    }
}
