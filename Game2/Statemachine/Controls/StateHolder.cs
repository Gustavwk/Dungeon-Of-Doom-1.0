using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.gameLogic.HUD_Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Menus.Controls
{
    class StateHolder
    {
        protected Mediator mediator;
        protected List<GameObject> stateObjects = new List<GameObject>();
        protected int x;
        protected int y;
        protected int unit = 32;
        protected GameTime gameTime;

        public StateHolder(int x, int y, Mediator mediator, GameTime gameTime)
        {
            this.gameTime = gameTime;
            this.mediator = mediator;
            this.x = x;
            this.y = y;
        }

        public List<GameObject> MenuObjects
        {
            get => stateObjects;
            set => stateObjects = value;
        }
        

        public void MenuBackground()
        {
            Random random = new Random();

            for (int i = 0; i < this.x; i += unit)
            {
                for (int j = 0; j < this.x; j += unit)
                {
                    stateObjects.Add(new HUDTile(i, j, random.Next(5), this.mediator));
                }
            }
        }
        public void StateUpdate(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
            foreach (GameObject gameObject in stateObjects)
            {
                
                gameObject.Update(gameTime);
            }
        }

        public virtual void stateDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in stateObjects)
            {
                gameObject.Load();
                gameObject.Draw(spriteBatch, gameTime);
            }
        }
    }
}
