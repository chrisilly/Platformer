using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace SuperMarioClone
{
    internal class Player : Actor
    {
        public Player(Rectangle size) : base(size)
        {
            this.speed = 250f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            CheckPlayerInput();
        }

        public void CheckPlayerInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                direction += new Vector2(-1, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                direction += new Vector2(1, 0);
            }
            else
            {
                direction.X = 0;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                direction += new Vector2(0, -1);
            }
            else
            {
                direction.Y = 0;
            }

            if(direction != Vector2.Zero)
                direction.Normalize();
        }

        private void DebugKeyPressed()
        {
            Debug.WriteLine("Key pressed. Variable speed: " + speed + ", direction: " + direction + ", position: " + position);
        }
    }
}
