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
            // Я всегда рекомендую выносить логику роботы из Main. Например в другой метод -> StartGame()/InitialGame()
            // Или что-то на подобие...
            area = new Area();
            status = Status.play;
            // мне не совсем нравится реализация через подписку на событие таймера. 
            // как то сильно долго приходиться ждать. 
            timer = new Timer(1500);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            while (status != Status.over)
            {
                area.newDirection(Console.ReadKey().Key);
                
            }
            Console.WriteLine($"GAME OVER!!! Your score: {area.TotalScore()}");

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
