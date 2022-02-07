using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        private static Area area;
        private static Status status;
        private static Thread ThreadPlayGame;
        private static int SpeedGame;
        static void Main(string[] args)
        {
            StartGame();
            while (status != Status.over)
            {
                area.NewDirection(Console.ReadKey().Key);
            }
        }

        private static void StartGame()
        {
            area = new Area(24);
            area.ViewGrid();
            SpeedGame = 400;
            status = Status.play;
            ThreadPlayGame = new Thread(PlayGame);
            ThreadPlayGame.Start();
        }
        private static void PlayGame()
        {
            while (true)
            {
                Thread.Sleep(SpeedGame);
                status = area.StatusCheck();
                if (status == Status.play)
                    area.MoveSnake();
                area.DrawSnake();

                if (status == Status.eat)
                {
                    area.EatFood();
                    status = Status.play;
                    if (SpeedGame > 80)
                        SpeedGame -= 20;
                }
                else if (status == Status.over)
                {
                    Console.WriteLine($"GAME OVER!!! Your score: {area.TotalScore()}");
                    return;
                }
            }
        }
    }
}
