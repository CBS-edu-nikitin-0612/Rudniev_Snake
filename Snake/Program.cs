using System;
using System.Timers;

namespace Snake
{
    class Program
    {
        private static Area area;
        private static Status status;
        private static Timer timer;
        static void Main(string[] args)
        {
            area = new Area();
            status = Status.play;
            timer = new Timer(2000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            while (status != Status.over)
            {
                area.newDirection(Console.ReadKey().Key);
                
            }
            Console.WriteLine("GAME OVER!!!");

        }

        private static void OnTimedEvent(object obj, ElapsedEventArgs e)
        {
            area.ViewGrid();
            status = area.statusCheck();
            if (status == Status.over)
            {
                timer.Stop();
                timer.Dispose();
            }
            if (status == Status.eat)
            {
                area.EatFood();
                status = Status.play;
            }

        }
    }
}
