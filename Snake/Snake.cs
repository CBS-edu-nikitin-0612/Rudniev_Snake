using System;

namespace Snake
{
    class Snake
    {
        private int size;
        public Direction direction;
        public int[,] Location;
        public int[,] phantomTail;
        public int Size { get => size; set => size = value; }


        public Snake() : this(12) { }
        public Snake(int sizeArea)
        {
            this.size = 3;
            int center = sizeArea / 2;
            direction = Direction.up;
            this.Location = new int[size, 2];
            for (int i = 0; i < size / 2; i++)
            {
                Location[i, 0] = sizeArea / 2 + i;
                Location[i, 1] = center;
            }
            phantomTail = new int[2, 2];
        }
        public void MoveSnake()
        {
            phantomTail[0, 0] = Location[size - 1, 0];
            phantomTail[0, 1] = Location[size - 1, 1];
            phantomTail[1, 0] = phantomTail[0, 0];
            phantomTail[1, 1] = phantomTail[0, 1];
            for (int i = size - 1; i > 0; i--)
            {
                Location[i, 0] = Location[i-1, 0];
                Location[i, 1] = Location[i-1, 1];
            }
            if (direction == Direction.up)
                Location[0, 0] -= 1;
            else if (direction == Direction.down)
                Location[0, 0] += 1;
            else if (direction == Direction.left)
                Location[0, 1] -= 1;
            else if (direction == Direction.right)
                Location[0, 1] += 1;

        }
        public void LengthUp()
        {
            int[,] temp = new int[size + 1, 2];
            temp[size, 0] = phantomTail[0, 0];
            temp[size, 1] = phantomTail[0, 1];
            phantomTail[0, 0] = phantomTail[1, 0];
            phantomTail[0, 1] = phantomTail[1, 1];
            for (int i = 0; i < size - 1; i++)
            {
                temp[i, 0] = Location[i, 0];
                temp[i, 1] = Location[i, 1];
            }
            size += 1;
            Location = new int[size,2];
            Location = temp;
            
        }

    }
}
