using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Data;

namespace WebApplication4.Controllers.Observer
{
    public class ConcreteSubject : SubjectObserver

    {
        private List<Exam> _subjects;
        private string _subjectState;

        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
        public ConcreteSubject(int userID)
        {
            _subjects = new List<Exam>();
            using (SimpleDataBase db = new SimpleDataBase())
            {
                
                db.SubjectGroup.ToList().ForEach(x =>
                {
                    if (x.ID_USER == userID)
                    {
                        _subjects.Add(db.Exam.Where(y => y.ID == x.ID_EXAM).FirstOrDefault());
                    }
                });
            }
        }
        public List<Exam> GetSubjects()
        {
            return _subjects;
        }
    }
}