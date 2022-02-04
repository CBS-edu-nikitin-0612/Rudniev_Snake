using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private ushort size;
        public Direction direction;
        public ushort[,] Location;
        private ushort[,] phantomTail;
        public ushort Size { get => size; set => size = value; }


        public Snake()
        {
            size = 3;
            direction = Direction.up;
            this.Location = new ushort[size, 2];
            for (int i = 0; i < size; i++)
            {
                Location[i, 0] = (ushort)(5 + i);
                Location[i, 1] = 5;
            }
            phantomTail = new ushort[1, 2];
        }
        public Snake(byte sizeArea)
        {
            size = 3;
            ushort center = (ushort)(sizeArea / 2 - 1);
            direction = Direction.up;
            this.Location = new ushort[size, 2];
            for (int i = 0; i < size / 2; i++)
            {
                Location[i, 0] = (ushort)(sizeArea / 2 - 1 + i);
                Location[i, 1] = center;
            }
            phantomTail = new ushort[1, 2];
        }
        public void Move()
        {
            phantomTail[0, 0] = Location[size - 1, 0];
            phantomTail[0, 1] = Location[size - 1, 1];
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
            ushort[,] temp = new ushort[size + 1, 2];
            temp[size, 0] = phantomTail[0, 0];
            temp[size, 1] = phantomTail[0, 1];
            for (int i = 0; i < size - 1; i++)
            {
                temp[i, 0] = Location[i, 0];
                temp[i, 1] = Location[i, 1];
            }
            Location = new ushort[size,2];
            Location = temp;
            size = ++size;
        }

    }
}
