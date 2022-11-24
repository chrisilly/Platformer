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
        Vector2 position;
        Vector2 velocity;
        float xRemainder, yRemainder;

        public Actor(Rectangle size) : base(size)
        {
            position.X = size.X; position.Y = size.Y;
        }

        // Celeste movement attempt
        //public int Sign(int direction)
        //{

        //    return direction;
        //}

        //public void MoveX(float amount, Action onCollide)
        //{
        //    xRemainder += amount;
        //    int move = (int)Math.Round(xRemainder);
        //    if (move != 0)
        //    {
        //        xRemainder -= move;
        //        int sign = Sign(move);
        //        while (move != 0)
        //        {
        //            if (!CollideAt(Solid.solidList, position + new Vector2(sign, 0)))
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
        //public void MoveY(float amount, Action onCollide)
        //{
        //    yRemainder += amount;
        //    int move = (int)Math.Round(yRemainder);
        //    if (move != 0)
        //    {
        //        yRemainder -= move;
        //        int sign = Sign(move);
        //        while (move != 0)
        //        {
        //            if (!CollideAt(Solid.solidList, position + new Vector2(0, sign)))
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

        //public virtual bool CollideAt(List<Solid> solidList, Vector2 position)
        //{
        //    foreach (Solid solid in solidList)
        //    {
        //        // Position is within the bounds of a solid on both X and Y axis simultaneously
        //        if(solid.size.X <= position.X && solid.size.X + solid.size.Width >= position.X)
        //            if(solid.size.Y <= position.Y && solid.size.Y + solid.size.Height >= position.Y)
        //                return true;
        //    }
        //    return false;
        //}
    }
}
