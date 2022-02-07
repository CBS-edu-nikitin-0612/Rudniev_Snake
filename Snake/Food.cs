using System;

namespace Snake
{
    struct Food
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void CreateNewFood(int sizeArea, Snake snake)
        {
            bool temp;
            do
            {
                temp = false;
                X = new Random().Next(1, sizeArea - 2);
                Y = new Random().Next(1, sizeArea - 2);
                for (int i = 0; i < snake.Location.Length / 2; i++)
                    if (X == snake.Location[i, 1] && Y == snake.Location[i, 0])
                        temp = true;
            } while (temp);
        }
    }
}
