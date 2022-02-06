using System;

namespace Snake
{
    struct Food
    {
        public byte X { get; private set; }
        public byte Y { get; private set; }

        public Food(byte sizeArea, Snake snake)
        {
            bool temp;
            do
            {
                temp = false;
                X = (byte)(new Random().Next(1, sizeArea - 2));
                Y = (byte)(new Random().Next(1, sizeArea - 2));
                for (int i = 0; i < snake.Location.Length / 2; i++)
                    if (X == snake.Location[i, 1] && Y == snake.Location[i, 0])
                        temp = true;
            } while (temp);
        }
    }
}
