using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowRezJam
{
    class Block
    {
        int id;
        string name;
        int rareness;
        Color drawColor;
        public Block()
        {
            id = 0;
            name = "Stone";
            rareness = 0;
            drawColor = Color.Black;
        }
        public Block(int blockID)
        {
            if (blockID == 999)
            {
                id = blockID;
                name = "Edge";
                rareness = 0;
                drawColor = Color.Red;
            }
            if (blockID == 0)
            {
                id = blockID;
                name = "Stone";
                rareness = 0;
                drawColor = Color.Black;
            }
            if (blockID == 1)
            {
                id = blockID;
                name = "Gravel";
                rareness = 0;
                drawColor = new Color(30,30,30);
            }

        }
        public Color DrawColor
        {
            get { return drawColor; }
            set { drawColor = value; }
        }

    }
}
