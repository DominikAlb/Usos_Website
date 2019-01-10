using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usososo.Controllers.Memento
{
    class Originator

    {
        private string _state;

        public string State
        {
            get { return _state; }
            set

            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }
        
        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
        static void Main()
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator

            o.State = "Off";

            // Restore saved state

            o.SetMemento(c.Memento);

            // Wait for user

            Console.ReadKey();
        }
    }

}