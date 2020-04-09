using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Models
{
    public class CandidateScore:BaseModel
    {
        public int QuestionnaireId { get; set; }
        public int QuestionNumber { get; set; }

        public int Response { get; set; }

        public CandidateScore(int questionnaireId,int questionNumber, int response)
        {
            QuestionnaireId = questionnaireId;
            QuestionNumber = questionNumber;
            Response = response;
        }
    }
}
