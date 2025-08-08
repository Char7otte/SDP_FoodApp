using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public enum State
        {
            Finished,
            Archived,
            Deleted
        }

        public State Status { get; set; }
        private DateTime date;
        public DateTime Date { get; set; }

        public Order(DateTime date)
        {
            Date = date;
            Status = State.Finished;
        }
    }
}
