using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    internal class GameObject
    {
        public Rectangle size { get; protected set; }
        protected Texture2D texture;
        protected Color color = Color.White;

        public GameObject(Rectangle size)
        {
            this.size = size;
            texture = Assets.tileTexture;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, color);
        }
    }
}
