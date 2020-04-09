using Microsoft.EntityFrameworkCore;
using ResilienceData.Entity;
using ResilienceData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData
{
    public class QuestionnaireRepository
    {
        public DataContext db;
        public QuestionnaireRepository(DataContext _db)
        {
            db = _db;
        }

        public List<QuestionnaireQuestion> GetQuestions(int id)
        {
            return db.Questions.Where(c => c.QuestionnaireId == id).ToList();
        }


    }
}
