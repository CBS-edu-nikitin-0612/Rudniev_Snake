using System;

namespace Snake
{
    class Area
    {
        private int size;
        public int Size
        {
            get => size;
            set
            {
                if (value <= 12)
                    size = 12;
                else if (value <= 16)
                    size = 16;
                else if (value <= 20)
                    size = 20;
                else if (value <= 24)
                    size = 24;
                else if (value <= 28)
                    size = 28;
                else if (value <= 32)
                    size = 32;
                else
                    size = 36;
            }
        }

        private char[,] grid;
        public char[,] Grid { get => grid; set => grid = value; }
        Snake snake;
        Food food;

        public Area() : this(12) { }
        public Area(int size)
        {
            this.Size = size;
            CreateGrid(size);
            this.snake = new Snake(size);
            this.food = new Food();
            this.food.CreateNewFood(size, snake);
        }

        private void CreateGrid(int size)
        {
            this.grid = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == 0)
                        grid[i, j] = '%';
                    else if (i + 1 == size)
                        grid[i, j] = '%';
                    else if (j == 0)
                        grid[i, j] = '%';
                    else if (j + 1 == size)
                        grid[i, j] = '%';
                    else
                        grid[i, j] = ' ';
        }
        public void ViewGrid()
        {
            CreateGrid(size);

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (grid[i, j] == '%')
                        Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(grid[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            DrawFood();
        }

        public void DrawSnake()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < snake.Location.Length / 2; i++)
                if (i == 0)
                {
                    Console.SetCursorPosition(snake.Location[i, 1], snake.Location[i, 0]);
                    Console.Write('@');
                }
                else
                {
                    Console.SetCursorPosition(snake.Location[i, 1], snake.Location[i, 0]);
                    Console.Write('#');
                }
            Console.SetCursorPosition(snake.phantomTail[0, 1], snake.phantomTail[0, 0]);
            Console.Write(' ');
            Console.SetCursorPosition(0, size + 1);
        }
        public void MoveSnake() => snake.MoveSnake();
        private void DrawFood()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write('$');
            Console.SetCursorPosition(0, size + 1);
        }

        public Status StatusCheck()
        {
            if (grid[snake.Location[0, 1], snake.Location[0, 0]] == '%')
                return Status.over;
            else if (snake.Location[0, 1] == food.X && snake.Location[0, 0] == food.Y)
                return Status.eat;
            for (int i = 2; i < snake.Size; i++)
                if (snake.Location[0, 0] == snake.Location[i, 0] && snake.Location[0, 1] == snake.Location[i, 1])
                    return Status.over;
            return Status.play;
        }

        public void NewDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    if (snake.direction != Direction.down)
                        snake.direction = Direction.up;
                    break;
                case ConsoleKey.A:
                    if (snake.direction != Direction.right)
                        snake.direction = Direction.left;
                    break;
                case ConsoleKey.S:
                    if (snake.direction != Direction.up)
                        snake.direction = Direction.down;
                    break;
                case ConsoleKey.D:
                    if (snake.direction != Direction.left)
                        snake.direction = Direction.right;
                    break;
            }
        }
        public void EatFood()
        {
            this.snake.LengthUp();
            this.food.CreateNewFood(size, snake);
            DrawFood();
        }
        public int TotalScore()
            => (snake.Size - 3) * 10;
    }
}
