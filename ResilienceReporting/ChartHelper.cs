using iTextSharp.text;
using ResilienceData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceReporting
{
    public static class ChartHelper
    {
        public static float ft(float Y)
        {
            return Utilities.MillimetersToPoints(Utilities.PointsToMillimeters(PageSize.A4.Height) - Y);
        }

        public static float mm(float mms)
        {
            return Utilities.MillimetersToPoints(mms);
        }

        public static ResultForChart GetMockResult()
        {
            return new ResultForChart()
            {
                Id = 0,
                CandidateId = 1,
                Supported = 0.5,
                Isolated = 1,
                Purposeful = 1.5,
                Aimless=2,
                Confident=2.5,
                Fearful=3,
                Adaptable=3.5,
                Fixed=4
            };
        }



    }

   



    public class Bar {
        public int llX { get; set; }
        public int llY { get; set; }
        public int urX { get; set; }
        public int urY { get; set; }

        public Bar(int llx,int lly, int urx,int ury)
        {

        }
    }
   
}
