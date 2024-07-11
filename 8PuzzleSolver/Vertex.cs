using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing; 
using System.Text;
using System.Threading.Tasks;

namespace _Failed8PuzzleSolver
{
    public class Vertex<T> where T : IComparable<T>
    {
        public int number;
        public bool isBlank;
        public Button button;
        Point location;
        public bool CanMove;
        public List<Vertex<T>> Neighbors; 

        public Vertex(int number, bool isBlank)
        {
            this.number = number;
            this.isBlank = isBlank;
            this.button = new Button()
            {
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(200, 200),
                Text = number.ToString(),
            };
            this.location = button.Location;
        }
        public void setPosition(Point point)
        {
            button.Location = new System.Drawing.Point(point.X * 200, point.Y * 200);
        }
    }


    public class Puzzle<T> where T : IComparable<T>
    {
        public Vertex<T>[,] tiles;

        public Puzzle(int size)
        {
            this.tiles = new Vertex<T>[size, size]; 
        }

        bool IsInBounds(int i, int j)
        {
            return i < 3 && j < 3 && i > -1 && j > -1;
        }
        public List<Point> findAdjacent()
        {
            List<Point> adjacent = new List<Point>(0);

            Point blankCellPosition = GetBlankCell();
            int i = blankCellPosition.X;
            int j = blankCellPosition.Y;

            if (IsInBounds(i, j - 1))
            {
                adjacent.Add(new Point(i, j - 1));
            }
            if (IsInBounds(i, j + 1))
            {
                adjacent.Add(new Point(i, j + 1));
            }
            if (IsInBounds(i - 1, j))
            {
                adjacent.Add(new Point(i - 1, j));
            }
            if (IsInBounds(i + 1, j))
            {
                adjacent.Add(new Point(i + 1, j));
            }
            return adjacent;
        }


        Random random = new Random(6);
        public void Shuffle(int iterations)
        {

            for (int i = 0; i < iterations; i++)
            {
                List<Point> possibleSwitches = findAdjacent();
                int randomSwitch = random.Next(possibleSwitches.Count);

                Point piont = GetBlankCell();
                Point randomTile = possibleSwitches[randomSwitch];

                Vertex<T> temp = tiles[randomTile.X, randomTile.Y];
                tiles[randomTile.X, randomTile.Y] = tiles[piont.X, piont.Y];
                tiles[piont.X, piont.Y] = temp;
            }
        }
        public Point GetBlankCell()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tiles[i, j].isBlank == true)
                    {
                        return new Point(i, j);
                    }
                }
            }
            return new Point(-1, -1);
        }

        public Point findTile(int buttonClicked)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tiles[i, j].button.Text == buttonClicked.ToString())
                    {
                        return new Point(i, j);
                    }
                }
            }
            throw new Exception("not found");
        }
    }

}
