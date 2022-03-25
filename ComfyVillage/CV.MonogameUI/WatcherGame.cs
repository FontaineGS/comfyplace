using CV.Agents;
using CV.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using CV.Agents.Animals;
using System.Linq;

namespace CV.MonogameUI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class WatcherGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        WorldResolver _resolver;
        CompleteWorld _world;
        Texture2D treeTexture;
        Texture2D rabbitTexture;
        Texture2D foxTexture;
        Texture2D[] coloredTexture;
        Texture2D blueTexture;
        Texture2D redTexture;
        int pixelSize = 2;

        double _timeSinceLastTurn = 0;

        public WatcherGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            WorldGenerator generator = new WorldGenerator();
            _world = generator.GenerateWorldTerrain();
            generator.Populate(_world);
            _resolver = new WorldResolver();
            _resolver.World = _world;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            treeTexture = Content.Load<Texture2D>("tree");
            rabbitTexture = Content.Load<Texture2D>("rabbit");
            foxTexture = Content.Load<Texture2D>("fox");

            coloredTexture = new Texture2D[256];
            coloredTexture = coloredTexture.Select(i => i = new Texture2D(GraphicsDevice, pixelSize, pixelSize)).ToArray();

            //get good color for color range (0 - 255 from something like 40 to 200)
            Color getGreen(int elevation)
            {
                var value = (float)(255 - elevation) * (120.0 / 255.0) + 80;
                return new Color((int)(value * 0.4), (int)value, (int)(value * 0.6));
            };
            for (int i = 0; i < coloredTexture.Length; i++)
            {
                coloredTexture[i].SetData<Color>((new Color[pixelSize * pixelSize]).Select(k => k = getGreen(i)).ToArray());
            }

            blueTexture = new Texture2D(GraphicsDevice, pixelSize, pixelSize);
            blueTexture.SetData((new Color[pixelSize * pixelSize]).Select(k => k = Color.LightBlue).ToArray());


            redTexture = new Texture2D(GraphicsDevice, pixelSize*3, pixelSize*3);
            redTexture.SetData((new Color[pixelSize*3 * pixelSize*3]).Select(k => k = Color.Red).ToArray());
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (_timeSinceLastTurn > 50)
            {
                _resolver.Resolve();
                
                _timeSinceLastTurn = 0;
            }
            else
            {
                _timeSinceLastTurn += gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            // TODO: Add your drawing code here

            // Terrain code
            for (int i = 0; i < _resolver.World.Terrain.SIZE; i++)
            {
                for (int j = 0; j < _resolver.World.Terrain.SIZE; j++)
                {
                    DrawElevation(i, j, (int)_resolver.World.Terrain.HeightMap[i, j]);
                }
            }

            DrawBall(_resolver.World.Terrain.Snowball.Item1, (_resolver.World.Terrain.Snowball.Item2));


            // Agents code
            /* foreach (var agent in _world.Agents)
             {
                 if (agent is Rabbit)
                     DrawRabbit(agent as Rabbit);
                 if (agent is Tree)
                     DrawTree(agent as Tree);
                 if (agent is Fox)
                     DrawFox(agent as Fox);
             }
            */

            base.Draw(gameTime);
        }

        private void DrawFox(Fox fox)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(foxTexture, new Vector2(fox.Location.X, fox.Location.Y), null, Color.White, 0f, new Vector2(foxTexture.Width / 2, foxTexture.Height / 2), Vector2.One,
                SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        private void DrawTree(Tree tree)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(treeTexture, new Vector2(tree.Location.X, tree.Location.Y), null, Color.White, 0f, new Vector2(treeTexture.Width / 2, treeTexture.Height / 2), Vector2.One,
SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        private void DrawRabbit(Rabbit rabbit)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(rabbitTexture, new Vector2(rabbit.Location.X, rabbit.Location.Y), null, Color.White, 0f, new Vector2(rabbitTexture.Width / 2, rabbitTexture.Height / 2), Vector2.One,
SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        private void DrawElevation(int x, int y, int elevation)
        {
            spriteBatch.Begin();
            if (elevation < 0)
                spriteBatch.Draw(blueTexture, new Vector2(x * pixelSize, y * pixelSize), Color.White);
            else if (elevation > 255)
                spriteBatch.Draw(blueTexture, new Vector2(x * pixelSize, y * pixelSize), Color.Red);
            else
                spriteBatch.Draw(coloredTexture[elevation], new Vector2(x * pixelSize, y * pixelSize), Color.White) ;


            spriteBatch.End();
        }

        private void DrawBall(int x, int y)
        {
            spriteBatch.Begin(); 
            spriteBatch.Draw(redTexture, new Vector2(x * pixelSize, y * pixelSize), Color.White);

            spriteBatch.End();
        }
    }
}
