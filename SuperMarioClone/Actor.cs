using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    internal class Actor : GameObject
    {
        protected Vector2 velocity; // = sign * amount // = direction * speed
        protected Vector2 direction;
        protected float speed;

        float xRemainder;
        float yRemainder;

        protected Vector2 gravityDirection = new Vector2(0, 1);
        protected float gravityAcceleration = 0.15f;

        public Actor(Rectangle size) : base(size)
        {

        }

        public Actor(Rectangle size, Color color) : base(size)
        {
            this.color = color;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Apply gravity to the object and update velocity
            if (IsMidAir())
            {
                velocity.X = direction.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                velocity.Y += gravityAcceleration;
            }
            else
                velocity = direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            MoveX(velocity.X, null);
            MoveY(velocity.Y, null);
        }

        public void MoveX(float amount, Action OnCollide)
        {
            xRemainder += amount;
            int move = (int)Math.Round(xRemainder);
            if (move != 0)
            {
                xRemainder -= move;
                int sign = Sign(move);
                while (move != 0)
                {
                    if (!CollideAt(Solid.solidList, new Vector2(sign, 0)))
                    {
                        //There is no Solid immediately beside us 
                        hitbox.X += sign;
                        move -= sign;
                    }
                    else
                    {
                        //Hit a solid!
                        if (OnCollide != null)
                            OnCollide();
                        break;
                    }
                }
            }
        }
        public void MoveY(float amount, Action OnCollide)
        {
            yRemainder += amount;
            int move = (int)Math.Round(yRemainder);
            if (move != 0)
            {
                yRemainder -= move;
                int sign = Sign(move);
                while (move != 0)
                {
                    if (!CollideAt(Solid.solidList, new Vector2(0, sign)))
                    {
                        //There is no Solid immediately beside us
                        hitbox.Y += sign;
                        move -= sign;
                    }
                    else
                    {
                        //Hit a solid!
                        if (OnCollide != null)
                            OnCollide();
                        break;
                    }
                }
            }
        }
        public int Sign(int move)
        {
            if (move > 0)
                return 1;
            else if (move < 0)
                return -1;
            else
                return 0;
        }

        public bool CollideAt(List<Solid> solids, Vector2 offset)
        {
            foreach (Solid solid in solids)
            {
                if (new Rectangle(Hitbox.X + (int)offset.X, Hitbox.Y + (int)offset.Y, Hitbox.Width, Hitbox.Height).Intersects(solid.Hitbox))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void OnCollide()
        {
            Debug.WriteLine("Collision!");
        }
        
        public bool IsMidAir()
        {
            if (!CollideAt(Solid.solidList, gravityDirection))
                return true;

            return false;
        }

    }
}
