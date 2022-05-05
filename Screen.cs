using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    public abstract class Screen
    {
        public int screenX { get; set; }
        public int screenY { get; set; }
        public int screenWidth { get; set; }
        public int screenHeight { get; set; }
        protected char[,] grid;
        public Screen()
        {
        }
        public void init()
        {
            grid = new char[screenWidth, screenHeight];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 't';
                }
            }
        }
        public void show()
        {
            draw_window();
        }
        protected void draw_window()
        {
            draw_screen_borders();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i + screenX, j + screenY);
                    Console.Write(grid[i, j]);
                }
            }
        }

        private void draw_screen_borders()
        {
            for (int i = 0; i <= screenWidth; i++)
            {
                // Top bar
                Console.SetCursorPosition(i + screenX - 1, screenY - 1);
                Console.Write("#");
                // Bottom bar
                Console.SetCursorPosition(i + screenX, screenHeight+screenY);
                Console.Write("#");
            }
            for (int i = 0; i <= screenHeight; i++)
            {
                // Left bar
                Console.SetCursorPosition(screenX - 1, screenY + i);
                Console.Write("#");
                // Right bar
                Console.SetCursorPosition(screenX+screenWidth, screenY + i - 1);
                Console.Write("#");
            }
        }

        public void setPixel(int x, int y, char symbol)
        {
            grid[x, y] = symbol; 
        }
        public void setPixel(int x, int y)
        {
            grid[x, y] = 'O';
        }
    }
}
