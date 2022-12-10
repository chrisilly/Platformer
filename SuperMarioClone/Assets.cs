using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    abstract internal class Assets
    {
        public static Texture2D tileTexture;

        public static void LoadTextures(ContentManager Content)
        {
            tileTexture = Content.Load<Texture2D>("tile");
            //ballTexture = Content.Load<Texture2D>("ball");
        }
    }
}
