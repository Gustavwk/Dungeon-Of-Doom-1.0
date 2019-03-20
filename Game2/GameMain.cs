using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private List<GameObject> allObjects = new List<GameObject>();
        Player.Player player;
        
        

        public GameMain()
        {
            
            graphics = new GraphicsDeviceManager(this);
            GameHolder.Game = this;
            Content.RootDirectory = "Content";

            
            player = new Player.Player(100,100);
            allObjects.Add(player);
            allObjects.Add(new Room(800,480));
            allObjects.Add(new HealthBoost(60, 60, 60));
            allObjects.Add(new Door(800 / 2, 480 / 2));
            

            
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
 

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (GameObject gameObject in allObjects)
            {
                gameObject.Load();
            }

            // Create a new SpriteBatch, which can be used to draw textures
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

            foreach (GameObject  gameObject in allObjects)
            {
               

                if (player.hitbox.Intersects(gameObject.hitbox))
                {
                    
                    player.intersects(gameObject);
                    gameObject.intersects(player);
                    
                }
                gameObject.Update(gameTime);

                if (gameObject is Room)
                {
                    Room room = (Room) gameObject;              
                    foreach (Wall wall  in room.walls)
                    {
                        if (player.hitbox.Intersects(wall.hitbox))
                        {
                            player.intersects(wall);
                            
                        }
                       
                    }
                  
                }
               
                    
                

                

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
    
            GraphicsDevice.Clear(Color.Azure);
            spriteBatch.Begin();

            foreach (GameObject gameObject in allObjects)
            {

                gameObject.Draw(spriteBatch, gameTime);
               
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
