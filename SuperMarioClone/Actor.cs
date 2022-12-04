using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    abstract internal class Actor : GameObject
    {
        protected Vector2 direction;
        protected Vector2 velocity; // = direction * speed
        protected float speed;
        protected float gravity = 9.8f;
        protected Vector2 gravityDirection = new Vector2(0, 1);

        float xRemainder;
        float yRemainder;

        public Actor(Rectangle size) : base(size)
        {

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
                    if (!CollideAt(Solid.solidList, /*position + */new Vector2(sign, 0)))
                    {
                        //There is no Solid immediately beside us 
                        position.X += sign;
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
                    if (!CollideAt(Solid.solidList, /*position + */new Vector2(0, sign)))
                    {
                        //There is no Solid immediately beside us 
                        position.Y += sign;
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

        public virtual void OnCollide()
        {
            Debug.WriteLine("Collision!");
        }

    }
}
