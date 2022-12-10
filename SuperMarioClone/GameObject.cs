using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    abstract internal class GameObject
    {
        protected Texture2D texture;
        protected Rectangle hitbox;
        public Rectangle Hitbox { get { return hitbox; } set { hitbox.X = value.X; hitbox.Y = value.Y; } }
        protected Color color = Color.White;

        public GameObject(Rectangle size)
        {
            texture = Assets.tileTexture;
            this.hitbox = size;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, color);
            //DrawHitbox(spriteBatch);
        }

        public void DrawHitbox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.FromNonPremultiplied(0, 0, 255, 127));
        }
    }
}
