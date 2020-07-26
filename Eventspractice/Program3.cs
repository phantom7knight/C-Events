using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Program3
{
    class EventLogic
    {
        public event EventHandler<bool> ProcessComplete;

        public void StartFunc(bool Condition)
        {
            this.FunctionInvoke(Condition);

            return;
        }

        private void FunctionInvoke(bool status)
        {
            this.ProcessComplete?.Invoke(this, status);
            return;
        }

    }



    class MainProgram
    {
        public static void Main()
        {
            EventLogic e1 = new EventLogic();

            e1.ProcessComplete += E1_ProcessComplete;

            e1.StartFunc(false);


            return;
        }

        private static void E1_ProcessComplete(object sender, bool e)
        {
            if (e)
            {
                Console.WriteLine("This is true");
            }
            else
            {
                Console.WriteLine("This is fales");
            }

            return;
        }
    }
}