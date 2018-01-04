using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake_Game
{
    public class Food
    {
        public Rectangle Piece;
        private int x, y, height = 10, width = 10;

        public Food(Random rand)
        {
            Generate(rand);
            Piece = new Rectangle(x, y, height, width);
        }

        public void Draw(Graphics graphics)
        {
            Piece.X = x;
            Piece.Y = y;
            graphics.FillRectangle(Brushes.Brown, Piece);
        }

        public void Generate(Random rand)
        {
            x = rand.Next(0, 30) * 10;
            y = rand.Next(0, 20) * 10;
        }

    }
}
