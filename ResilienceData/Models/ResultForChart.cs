using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Models
{
    public class ResultForChart
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public double Supported { get; set; }
        public double Isolated { get; set; }
        public double Purposeful { get; set; }
        public double Aimless { get; set; }
        public double Confident { get; set; }
        public double Fearful { get; set; }
        public double Adaptable { get; set; }
        public double Fixed { get; set; }

        public ResultForChart()
        {

        }
    }
}
