using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowRezJam
{
    class Player
    {
        Vector2 location;
        float lightStrength;
        public Player()
        {
            location = new Vector2(250, 250);
            lightStrength = 0.5f;
        }

        public void Update(KeyboardState current, KeyboardState old, Block[,] map)
        {
            if (current.IsKeyDown(Keys.Up) && !old.IsKeyDown(Keys.Up))
            {
                if (map[(int)location.X, (int)location.Y - 1].Id == -1)
                {
                    location.Y -= 1;
                } 
                else if (map[(int)location.X, (int)location.Y - 1].Id != 999)
                {
                    map[(int)location.X, (int)location.Y - 1] = new Block(-1);
                }
            }
            if (current.IsKeyDown(Keys.Down) && !old.IsKeyDown(Keys.Down))
            {
                if (map[(int)location.X, (int)location.Y + 1].Id == -1)
                {
                    location.Y += 1;
                }
                else if (map[(int)location.X, (int)location.Y + 1].Id != 999)
                {
                    map[(int)location.X, (int)location.Y + 1] = new Block(-1);
                }
            }
            if (current.IsKeyDown(Keys.Left) && !old.IsKeyDown(Keys.Left))
            {
                if (map[(int)location.X - 1, (int)location.Y].Id == -1)
                {
                    location.X -= 1;
                }
                else if(map[(int)location.X - 1, (int)location.Y].Id != 999)
                {
                    map[(int)location.X - 1, (int)location.Y] = new Block(-1);
                }
            }
            if (current.IsKeyDown(Keys.Right) && !old.IsKeyDown(Keys.Right))
            {
                if (map[(int)location.X + 1, (int)location.Y].Id == -1)
                {
                    location.X += 1;
                }
                else if (map[(int)location.X + 1, (int)location.Y].Id != 999)
                {
                    map[(int)location.X + 1, (int)location.Y] = new Block(-1);
                }
            }
        }

        public Block[,] DigStart(Block[,] map, int size)
        {

            for(int i = (int)location.X - size; i < location.X + size; i++)
            {
                for (int j = (int)location.Y - size; j < location.Y + size; j++)
                {
                    try {
                        if (map[i, j].Id != 999)
                        {
                            map[i, j] = new Block(-1);
                        }
                    }
                    catch(Exception e)
                    {

                    }
                }
            }

            return map;
        }
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public float LightStrength
        {
            get { return lightStrength; }
        }
    }
}
