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
        bool isJumping;

        public Player(Rectangle size) : base(size)
        {
            this.speed = 250f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            velocity = direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            CheckPlayerInput();
        }

        public void CheckPlayerInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
                MoveX(velocity.X, OnCollide);
                DebugKeyPressed();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
                MoveX(velocity.X, OnCollide);
                DebugKeyPressed();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Jump();
                MoveY(velocity.Y, OnCollide);
                DebugKeyPressed();
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                direction = new Vector2(0, 1);
                MoveY(velocity.Y, OnCollide);
            }
            else
            {
                direction = Vector2.Zero;
            }
        }

        public void Jump()
        {
            direction = new Vector2(0, -1);
        }

        private void DebugKeyPressed()
        {
            Debug.WriteLine("Key pressed. Variable speed: " + speed + ", direction: " + direction + ", position: " + position);
        }
    }
}
