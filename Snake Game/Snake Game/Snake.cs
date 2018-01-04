﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake_Game
{
    public class Snake
    {
        public Rectangle[] Body;
        private int x = 0, y = 0, height = 10, width = 10;

        public Snake()
        {
            Body = new Rectangle[1];
            Body[0] = new Rectangle(x, y, width, height);
        }
        public void Draw()
        {
            for (int i = Body.Length - 1; i > 0; i--) Body[i] = Body[i - 1];
        }
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangles(Brushes.Green, Body);
        }
        public void Move(int direction)
        {
            Draw();
            switch(direction)      // 0 = Right, 1 = Down, 2= Left, 3 = Up
            {
                case 0:
                    Body[0].X += 10;
                    break;
                case 1:
                    Body[0].Y += 10;
                    break;
                case 2:
                    Body[0].X -= 10;
                    break;
                case 3:
                    Body[0].Y -= 10;
                    break;
            }
        }
        public void Grow()
        {
            List<Rectangle> temp = Body.ToList(); //ToList() is a function of System.Linq; and List is a function of System.Collections.Generic;
            temp.Add(new Rectangle(Body[Body.Length - 1].X, Body[Body.Length - 1].Y,width,height));
            Body = temp.ToArray();
        }
    }
}
