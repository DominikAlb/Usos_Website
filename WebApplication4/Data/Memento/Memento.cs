using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usososo.Controllers.Memento
{
    public class Memento

    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        public string State
        {
            get { return _state; }
        }


    }
}