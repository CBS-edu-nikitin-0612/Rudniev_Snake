using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Area
    {
        private byte size;
        public byte Size
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
                else
                    size = 24;
            }
        }

        private char[,] grid;
        public char[,] Grid { get => grid; set => grid = value; }
        Snake snake;
        Food food;

        public Area()
        {
            this.size = 12;
            this.snake = new Snake();
            this.food = new Food(size, snake);
        }
        public Area(byte size)
        {
            this.Size = size;
            this.snake = new Snake(size);
            this.food = new Food(size, snake);
        }

        private void createGrid(byte size)
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
        private void addSnakeToGrid()
        {
            for (int i = 0; i < snake.Location.Length / 2; i++)
                if (i == 0)
                    grid[snake.Location[i, 0], snake.Location[i, 1]] = '@';
            else
                    grid[snake.Location[i, 0], snake.Location[i, 1]] = '#';
        }
        private void addFoodToGrid()
        {
            grid[food.X, food.Y] = '$';
        }
        public void ViewGrid()
        {
            createGrid(size);
            addFoodToGrid();
            snake.Move();
            addSnakeToGrid();

            Console.Clear();
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (grid[i, j] == '%')
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(grid[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }

        }
        public Status statusCheck()
        {
            if (grid[snake.Location[0, 1], snake.Location[0, 0]] == '%' 
                || grid[snake.Location[0, 1], snake.Location[0, 0]] == '#')
                return Status.over;
            else if (grid[snake.Location[0, 1], snake.Location[0, 0]] == '$')
                return Status.eat;
            return Status.play;
        }

        public void newDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    snake.direction = Direction.up;
                    break;
                case ConsoleKey.A:
                    snake.direction = Direction.left;
                    break;
                case ConsoleKey.S:
                    snake.direction = Direction.down;
                    break;
                case ConsoleKey.D:
                    snake.direction = Direction.right;
                    break;
            }
        }
        public void EatFood()
        {
            this.snake.LengthUp();
            this.food = new Food(size, snake);
        }
    }
}
