using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.Observer
{
    public class ConcreteObserver : Observer

    {
        private string _observerState;
        private ConcreteSubject _subject;
        

        public ConcreteObserver(
          ConcreteSubject subject)
        {
            this._subject = subject;
        }

        public override string Update()
        {
            _observerState = _subject.SubjectState;
            return "masz " + _subject.GetSubjects().Where(x => x.Date.Equals(DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year)).ToList().Count + " sprawdzianów w terminie " + _observerState;
        }
        

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }
}