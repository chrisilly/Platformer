using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioClone
{
    abstract internal class ActorManager
    {
        public static Player player;
        public static Actor goal;
        public static List<Enemy> enemyList = new List<Enemy>();

        public ActorManager() { }

        public static void ResetPlayer(string fileName)
        {
            player.Hitbox = GetPlayerStartRectangle(fileName);
        }

        public static Rectangle GetPlayerStartRectangle(string fileName)
        {
            return JsonParser.GetRectangle(fileName, "player");
        }

        public static void UpdateActors(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.R))
                ResetPlayer("level.json");

            player.Update(gameTime);
            CollisionHandler("level.json");
        }

        public static void CollisionHandler(string fileName)
        {
            if (player.Hitbox.Intersects(goal.Hitbox))
            {
                ResetPlayer(fileName);
                Debug.WriteLine("You win!");
            }
            else
            {
                foreach (Enemy enemy in enemyList)
                {
                    if (player.Hitbox.Intersects(enemy.Hitbox))
                        ResetPlayer(fileName);
                }
            }
        }

        public static void DrawActors(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemyList)
                enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
            goal.Draw(spriteBatch);
        }
    }
}
