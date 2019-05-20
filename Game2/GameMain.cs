using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Game2.Creeps;
using Game2.gameLogic;
using Game2.Menus.Controls;
using Game2.Menus.States;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>C:\Users\gusta\source\repos\monogameExample\Game2\gameLogic\Mediator.cs
    /// This is the main type for your game.
    /// </summary>
    public class GameMain : Game
    {
        private Room room;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private List<GameObject> allObjects = new List<GameObject>();
        private List<GameObject> itemsToBeAdded = new List<GameObject>();
        
        private List<GameObject> itemsToBeDeleted = new List<GameObject>();
        private ActualGameState gameState = new ActualGameState(GameState.MENU);
        private GameTime gameTime;
        Player.Player player = new Player.Player(33,230);
        Mediator mediator;
        

        private StartMenu startMenu;
        private GameOverMenu gameOverMenu;
    
        
        public GameMain()
        { 
            graphics = new GraphicsDeviceManager(this);
            
            room = new Room(800, 480, mediator);
            Mediator.Game = this;
            Content.RootDirectory = "Content";
            mediator = new Mediator(allObjects, itemsToBeAdded, itemsToBeDeleted, player, room,gameState);           
            room.mediator = mediator;
            room.initRandomLevel();  
            itemsToBeAdded.Add(player);
            player.mediator = mediator;
            allObjects.Add(new HUD(800,100, mediator));
            startMenu = new StartMenu(800,580,mediator,gameTime);
            gameOverMenu = new GameOverMenu(800,580,mediator,gameTime);
            mediator.gameOverMenu = gameOverMenu;

            graphics.PreferredBackBufferHeight = 580;
            graphics.ApplyChanges();
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
            this.gameTime = gameTime;
            switch (this.gameState.State)
            {
                case GameState.PLAY:
                    PlayUpdate(gameTime);
                    break;
                case GameState.MENU:
                    startMenu.StateUpdate(gameTime,spriteBatch);
                    break;
                case GameState.GAMEOVER:
                    gameOverMenu.StateUpdate(gameTime,spriteBatch);
                    break;
                   
            }
        }

        

        private void PlayUpdate(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
          

            foreach (var gameObject in allObjects)
            {
                if (player.hitbox.Intersects(gameObject.hitbox))
                {
                    player.intersects(gameObject);
                    gameObject.intersects(player);
                }

                
                foreach (var otherGameObject in allObjects)
                {
                    if (gameObject.hitbox.Intersects(otherGameObject.hitbox))
                    {
                        gameObject.intersects(otherGameObject);
                    }
                }


                gameObject.Update(gameTime);
            }

            itemsToBeAdded.Sort();


            foreach (var gameObject in itemsToBeAdded)
            {
                gameObject.Load();
            }

           
            
            allObjects.AddRange(itemsToBeAdded);
            itemsToBeAdded.Clear();
          

            foreach (var gameObject in itemsToBeDeleted)
            {
                allObjects.Remove(gameObject);
            }
            itemsToBeDeleted.Clear();
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

            switch (this.gameState.State)
            {
                case GameState.PLAY:
                    PlayDraw(gameTime);
                    break;

                case GameState.MENU:
                    startMenu.stateDraw(gameTime,spriteBatch);
                    break;
                case GameState.GAMEOVER:
                    gameOverMenu.stateDraw(gameTime, spriteBatch);
                    break;
            }

            base.Draw(gameTime);
            spriteBatch.End();
        }

       

        private void PlayDraw(GameTime gameTime)
        {
            foreach (GameObject gameObject in allObjects)
            {
               
                    gameObject.Draw(spriteBatch, gameTime);
                
            }

            
        }
    }
}
