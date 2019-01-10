using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usososo.Controllers.Memento
{
    public class Caretaker
    {
        private Memento _memento;

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}