using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        private int direction = 0; //Right..
        private int score = 1;
        private Timer gameLoop = new Timer();
        private Random rand = new Random();
        private Graphics graphics;
        private Snake snake;
        private Food food;

        public Form1()
        {
            InitializeComponent();
            snake = new Snake();
            food = new Food(rand);
            gameLoop.Interval = 175;
            gameLoop.Tick += Update;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Enter:
                    if(lblMenu.Visible)
                    {
                        lblMenu.Visible = false;
                        gameLoop.Start();
                    }
                    break;
                case Keys.Space:
                    if (!lblMenu.Visible)  gameLoop.Enabled = (gameLoop.Enabled) ? false : true;
                    break;
                case Keys.Right:
                    if (direction != 2) direction = 0;
                    break;
                case Keys.Left:
                    if (direction != 0) direction = 2;
                    break;
                case Keys.Up:
                    if (direction != 1) direction = 3;
                    break;
                case Keys.Down:
                    if (direction != 3) direction = 1;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            snake.Draw(graphics);
            food.Draw(graphics);
        }
        private void Update(object sender, EventArgs e)
        {
            this.Text = string.Format("Snake - Score: {0}", score);
            snake.Move(direction);

            for (int i = 1; i < snake.Body.Length; i++)
            {
                if (snake.Body[0].IntersectsWith(snake.Body[i])) //Death by cannibalism..
                {
                    Restart();
                }
                if (snake.Body[0].X < 0 || snake.Body[0].X < 290 || snake.Body[0].Y < 0 || snake.Body[0].Y < 190) //hitting the wall..
                {
                    Restart();
                }
                if(snake.Body[0].IntersectsWith(food.Piece))  //Eating food and growing..
                {
                    score++;
                    snake.Grow();
                    food.Generate(rand);
                }
            }
            this.Invalidate();
        }
        private void Restart()
        {
            gameLoop.Stop();
            graphics.Clear(SystemColors.Control);
            snake = new Snake();
            food = new Food(rand);
            direction = 0;
            score = 1;
            lblMenu.Visible = true;
        }
    }
}
