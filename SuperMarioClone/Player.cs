using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    internal class Player : Actor
    {
        public Player(Rectangle size) : base(size)
        {
            
        }

        public void PlayerController()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                
            }
        }
    }
}
