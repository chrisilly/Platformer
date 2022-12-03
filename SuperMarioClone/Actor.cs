using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    abstract internal class Actor : GameObject
    {
        protected Vector2 direction;
        protected float speed;
        protected float gravity = 9.8f;
        protected Vector2 gravityDirection = new Vector2(0, 1);

        public Actor(Rectangle size) : base(size)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move(gameTime);
        }

        public virtual void Move(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (!CollideAt(Solid.solidList, position + direction))
            //{
            //}
            //else
            //{
            //    //OnCollide()
            //}
        }

        public bool CollideAt(List<Solid> solids, Vector2 offset)
        {
            foreach (Solid solid in solids)
            {
                if (new Rectangle(Hitbox.X + (int)position.X, Hitbox.Y + (int)position.Y, Hitbox.Width, Hitbox.Height).Intersects(solid.Hitbox))
                {
                    return true;
                }
            }
            return false;
        }

        //public void MoveX(float amount, Action onCollide)
        //{
        //    xRemainder += amount;
        //    int move = Round(xRemainder);
        //    if (move != 0)
        //    {
        //        xRemainder -= move;
        //        int sign = Sign(move);
        //        while (move != 0)
        //        {
        //            if (!collideAt(solids, Position + new Vector2(sign, 0))
        //            {
        //                //There is no Solid immediately beside us 
        //                position.X += sign;
        //                move -= sign;
        //            }
        //            else
        //            {
        //                //Hit a solid!
        //                if (onCollide != null)
        //                    onCollide();
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
