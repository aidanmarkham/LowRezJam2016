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
            id = blockID;
            if (blockID == 999)
            {
                name = "Edge";
                rareness = 0;
                drawColor = Color.Red;
            }
            if(blockID == -1)
            {

                name = "Air";
                rareness = 0;
                drawColor = new Color(0, 0, 0, 0);
            }
            if (blockID == 0)
            {
                
                name = "Stone";
                rareness = 0;
                drawColor = Color.Black;
            }
            if (blockID == 1)
            {
                
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
        public int Id
        {
            get { return id; }
        }

    }
}
