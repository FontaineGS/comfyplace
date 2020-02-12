using CV.Agents;
using CV.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CV.Monogame
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

            if (_timeSinceLastTurn > 10)
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
            GraphicsDevice.Clear(Color.LightGreen);

            // TODO: Add your drawing code here

            foreach (var agent in _world.Agents)
            {
                if (agent is Rabbit)
                    DrawRabbit(agent as Rabbit);
                if (agent is Tree)
                    DrawTree(agent as Tree);
            }

            base.Draw(gameTime);
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
    }
}
