using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.CommandClasses
{
    public class OrderController
    {
        private OrderCommand command = null!;

        public void SetCommand(OrderCommand command)
        {
            this.command = command;
        }

        public void SubmitOrder()
        {
            if (command !=  null)
            {

                command.Execute();
            }
            else
            {
                Console.WriteLine("No command set!");
            }
        }

        public void UndoOrder()
        {
            if (command != null)
            {
                command.Undo();
            }
            else
            {
                Console.WriteLine("No command to undo!");
            }
        }
    }
}