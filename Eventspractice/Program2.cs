using System;
using System.Collections.Generic;
using System.Text;


namespace Program2
{
    class EventLogic
    {
        public event EventHandler ProcessCompleted;

        // Starter Function
        public void StartFunc()
        {
            Console.WriteLine("This is in the StartFunc of Event Logic");
            this.ProcessCompletedFunc(EventArgs.Empty);

            return;
        }

        public void ProcessCompletedFunc(EventArgs e)
        {
            // Invoke the event
            this.ProcessCompleted?.Invoke(this, e);
        }


    }

    class Program1
    {
        public void StartFunc(EventLogic e)
        {
            e.ProcessCompleted += E_ProcessCompleted;
        }

        private void E_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("In Execution 2");
            return;
        }
    }



    class MainProgram
    {
        public static void Main()
        {
            EventLogic e1 = new EventLogic();
            Program1 p1 = new Program1();

            e1.ProcessCompleted += E1_ProcessCompleted;
            p1.StartFunc(e1);

            e1.StartFunc();


            return;
        }

        private static void E1_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("In Execution 1 ");
            return;
        }
    }

}