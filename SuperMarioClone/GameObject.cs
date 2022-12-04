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
        private Rectangle size;
        public Rectangle Hitbox { get { return size; } }
        protected Vector2 position;
        protected Color color = Color.White;



        public GameObject(Rectangle size)
        {
            texture = Assets.tileTexture;
            this.size = size;
            this.position = new Vector2(size.X, size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {
            size.X = (int)position.X;
            size.Y = (int)position.Y;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, color);
            //DrawHitbox(spriteBatch);
        }

        public void DrawHitbox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Hitbox, Color.FromNonPremultiplied(0, 0, 255, 127));
        }
    }
}
