 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Controllers.Observer
{
    public abstract class SubjectObserver
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public string Notify()
        {
            string log = "";
            foreach (Observer o in _observers)
            {
                log += o.Update();
            }
            return log;
        }
    }
}