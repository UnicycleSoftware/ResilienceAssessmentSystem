using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Models
{
    public class CandidateCalculatedResult: BaseModel
    {
        public int CandidateId { get; set; }
        public int Score { get; set; }
        public int ScoreType { get; set; }
        public int QuestionnaireId { get; set; }
        public DateTime Date { get; set; }
        public int MyProperty { get; set; }
    }
}
