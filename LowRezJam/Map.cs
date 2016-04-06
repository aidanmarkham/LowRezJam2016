
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowRezJam
{
    class Map
    {
        Block[,] data;
        Texture2D texture;
        Random rand;
        public Map(int size, GraphicsDevice gd)
        {
            data = new Block[size, size];
            texture = new Texture2D(gd, size, size);
        }

        public void Generate()
        {
            rand = new Random();
            
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    
                    data[i, j] = new Block(rand.Next(0,2));
                }
            }
            


            for(int i = 0; i < data.GetLength(0); i++)
            {
                data[0, i] = new Block(999);
                data[data.GetLength(0) - 1, i] = new Block(999);
            }
            for (int i = 1; i < data.GetLength(0)-1; i++)
            {
                data[i, 0] = new Block(999);
                data[i, data.GetLength(0) - 1] = new Block(999);
            }



        }

        public void UpdateImage()
        {
            Color[,] colorData = new Color[data.GetLength(0),data.GetLength(1)];
            for (int i = 0; i < colorData.GetLength(0); i++)
            {
                for(int j = 0; j < colorData.GetLength(1); j++)
                {
                    colorData[i, j] = data[i, j].DrawColor;
                }
            }
            Color[] imageData = new Color[data.GetLength(0) * data.GetLength(1)];
            for (int i = 0; i < colorData.GetLength(0); i++)
            {
                for (int j = 0; j < colorData.GetLength(1); j++)
                {
                    imageData[i + j*colorData.GetLength(1)] = colorData[i, j];
                }
            }
            texture.SetData(imageData);
        }
        public void Draw(Vector2 location, Rectangle drawArea, SpriteBatch sb)
        {
            Vector2 center = new Vector2(drawArea.X + drawArea.Width/2, drawArea.Y + drawArea.Height/2);

            Vector2 drawLoc = center - location;
            sb.Draw(texture, drawLoc, Color.White);
        }
    }
}
