using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SuperMarioClone
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Player player;
        List<Enemy> enemyList;
        List<Solid> solidList;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            solidList = new List<Solid>();
            enemyList = new List<Enemy>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.LoadTextures(Content);

            ReadFromFile("level.json");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            foreach (Solid solid in solidList)
                solid.Draw(spriteBatch);
            foreach (Enemy enemy in enemyList)
                enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void ReadFromFile(string fileName)
        {
            Rectangle playerRectangle = JsonParser.GetRectangle(fileName, "player");
            player = new Player(playerRectangle);
            List<Rectangle> solidRectangleList = JsonParser.GetRectangleList(fileName, "solid");
            foreach (Rectangle rectangle in solidRectangleList)
            {
                Solid solid = new Solid(rectangle);
                solidList.Add(solid);
            }
            List<Rectangle> enemyRectangleList = JsonParser.GetRectangleList(fileName, "enemy");
            foreach (Rectangle rectangle in enemyRectangleList)
            {
                Enemy enemy = new Enemy(rectangle);
                enemyList.Add(enemy);
            }
        }

        private void WriteToFile(string fileName)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            for (int i = 0; i < 4; i++)
            {
                Solid solid = new Solid(new Rectangle(i * 100, i * 100 + 75, 120, 50));
                gameObjectList.Add(solid);
                Enemy enemy = new Enemy(new Rectangle(i * 100, i * 100 + 50, 25, 25));
                gameObjectList.Add(enemy);
            }

            Player newPlayer = new Player(new Rectangle(150, 125, 50, 50));
            gameObjectList.Add(newPlayer);

            JsonParser.WriteJsonToFile(fileName, gameObjectList);
        }
    }

}