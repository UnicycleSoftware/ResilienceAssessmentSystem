using ResilienceData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResilienceReporting
{
    public class CalculationHelper
    {
        public ResultForChart CalculateResilianceChartData(List<CandidateScore> rawScores)
        {
            var processed = new ResultForChart();
            var q1 = rawScores.Where(c => c.QuestionNumber ==   1 ).FirstOrDefault().Response;
            var q2 = rawScores.Where(c => c.QuestionNumber ==   2 ).FirstOrDefault().Response;
            var q3 = rawScores.Where(c => c.QuestionNumber ==   3 ).FirstOrDefault().Response;
            var q4 = rawScores.Where(c => c.QuestionNumber ==   4 ).FirstOrDefault().Response;
            var q5 = rawScores.Where(c => c.QuestionNumber ==   5 ).FirstOrDefault().Response;
            var q6 = rawScores.Where(c => c.QuestionNumber ==   6 ).FirstOrDefault().Response;
            var q7 = rawScores.Where(c => c.QuestionNumber ==   7 ).FirstOrDefault().Response;
            var q8 = rawScores.Where(c => c.QuestionNumber ==   8 ).FirstOrDefault().Response;
            var q9 = rawScores.Where(c => c.QuestionNumber ==   9 ).FirstOrDefault().Response;
            var q10 = rawScores.Where(c => c.QuestionNumber ==  10).FirstOrDefault().Response;
            var q11 = rawScores.Where(c => c.QuestionNumber ==  11).FirstOrDefault().Response;
            var q12 = rawScores.Where(c => c.QuestionNumber ==  12).FirstOrDefault().Response;
            var q13 = rawScores.Where(c => c.QuestionNumber ==  13).FirstOrDefault().Response;
            var q14 = rawScores.Where(c => c.QuestionNumber ==  14).FirstOrDefault().Response;
            var q15 = rawScores.Where(c => c.QuestionNumber ==  15).FirstOrDefault().Response;
            var q16 = rawScores.Where(c => c.QuestionNumber ==  16).FirstOrDefault().Response;
            var q17 = rawScores.Where(c => c.QuestionNumber ==  17).FirstOrDefault().Response;
            var q18 = rawScores.Where(c => c.QuestionNumber ==  18).FirstOrDefault().Response;
            var q19 = rawScores.Where(c => c.QuestionNumber ==  19).FirstOrDefault().Response;
            var q20= rawScores.Where(c => c.QuestionNumber ==   20).FirstOrDefault().Response;
            var q21= rawScores.Where(c => c.QuestionNumber ==   21).FirstOrDefault().Response;
            var q22= rawScores.Where(c => c.QuestionNumber ==   22).FirstOrDefault().Response;
            var q23 = rawScores.Where(c => c.QuestionNumber ==  23).FirstOrDefault().Response;
            var q24 = rawScores.Where(c => c.QuestionNumber ==  24).FirstOrDefault().Response;


           processed.Adaptable = RoundtoHalf(((q16 + q14 + q24) / 3d)); //1.5

            processed.Confident = RoundtoHalf(((q1 + q20 + q18) / 3d)); //3.5

            processed.Purposeful = RoundtoHalf(((q21 + q12 + q6) / 3d)); //1

            processed.Supported = RoundtoHalf(((q10 + q3 + q8) / 3d)); //2.5

            processed.Fixed = RoundtoHalf(((q4 + q5 + q23) / 3d)); //-0.5

            processed.Fearful = RoundtoHalf(((q22 + q11 + q2) / 3d)); //-1.5

            processed.Aimless = RoundtoHalf(((q15 + q13 + q9) / 3d)); //-2

            processed.Isolated = RoundtoHalf(((q19 + q17 + q7) / 3d)); //-2.5


            return processed;
        }

        private double RoundtoHalf(double input)
        {
            double whole = Math.Floor(input);
            double remainder = input - whole;
            if (remainder < 0.3)
            {
                remainder = 0;
            }
            else if (remainder < 0.8)
            {
                remainder = 0.5;
            }
            else
            {
                remainder = 1;
            }
            return whole + remainder;
        }


        public List<CandidateScore> mockdata()
        {
            var mock = new List<CandidateScore>();
            mock.Add(new CandidateScore(1, 1 , 4));
            mock.Add(new CandidateScore(1, 2 , -3));
            mock.Add(new CandidateScore(1, 3 , 2));
            mock.Add(new CandidateScore(1, 4 , -1));
            mock.Add(new CandidateScore(1, 5 , 0));
            mock.Add(new CandidateScore(1, 6 , 1));
            mock.Add(new CandidateScore(1, 7 , -2));
            mock.Add(new CandidateScore(1, 8 , 3));
            mock.Add(new CandidateScore(1, 9 , -4));
            mock.Add(new CandidateScore(1, 10, 3));
            mock.Add(new CandidateScore(1, 11, -2));
            mock.Add(new CandidateScore(1, 12, 1));
            mock.Add(new CandidateScore(1, 13, 0));
            mock.Add(new CandidateScore(1, 14, 1));
            mock.Add(new CandidateScore(1, 15, -2));
            mock.Add(new CandidateScore(1, 16, 2));
            mock.Add(new CandidateScore(1, 17, -3));
            mock.Add(new CandidateScore(1, 18, 4));
            mock.Add(new CandidateScore(1, 19, -3));
            mock.Add(new CandidateScore(1, 20, 2));
            mock.Add(new CandidateScore(1, 21, 1));
            mock.Add(new CandidateScore(1, 22, 0));
            mock.Add(new CandidateScore(1, 23, 1));
            mock.Add(new CandidateScore(1, 24, 2));

            return mock;
        }

        public void Debug()
        {
            var mock = mockdata();
            CalculateResilianceChartData(mock);
        }


    }
}
