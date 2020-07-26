using System;
using System.Runtime.CompilerServices;

namespace Program1
{
    // Delegate function call
    public delegate void Notify();

    // Publisher
    class EventLogic
    {
        // Event
        public event Notify ProcessCompleted;

        public void TestingFunc()
        {
            Console.WriteLine("Currently in the Func1");

            OnProcessCompleted();

            return;
        }

        protected virtual void OnProcessCompleted()
        {
            this.ProcessCompleted?.Invoke();
        }


    }

    class TestingProgram1
    {
        public void E3_ProcessCompleted()
        {
            Console.WriteLine("Currenly in TestingProgram1 Class!");
            Console.WriteLine("Process Completed 3!");
        }
    }

    class TestingProgram2
    {
        public void Func2(EventLogic e2)
        {
            e2.ProcessCompleted += E4_ProcessCompleted;

            return;
        }

        public void E4_ProcessCompleted()
        {
            Console.WriteLine("Currently in TestingProgram2!");
            Console.WriteLine("Process Completed 4!");

            return;
        }


    }


    class Program
    {
        public static void Main()
        {
            EventLogic e1 = new EventLogic();
            TestingProgram1 p1 = new TestingProgram1();

            TestingProgram2 p2 = new TestingProgram2();

            // Register to the events
            e1.ProcessCompleted += E1_ProcessCompleted;
            e1.ProcessCompleted += E2_ProcessCompleted;

            // Register another class's event
            e1.ProcessCompleted += p1.E3_ProcessCompleted;

            // Call Testing Program's Event Handler
            p2.Func2(e1);

            e1.TestingFunc();

            return;
        }

        // Event Handlers
        private static void E1_ProcessCompleted()
        {
            Console.WriteLine("Currently in the Event Handler in Main");
            Console.WriteLine("Process Complete 1!");
        }

        private static void E2_ProcessCompleted()
        {
            Console.WriteLine("Currently in the 2nd Event Handler in Main");
            Console.WriteLine("Process Completed 2!");
            return;
        }

    }



}
