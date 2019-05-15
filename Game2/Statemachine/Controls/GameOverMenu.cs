using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Menus.Controls
{
    class GameOverMenu : StateHolder
    {
        private SpriteFont spriteFont;
        private Color textColor = Color.LightYellow;
        private int playerKills;

        public Player.Player player= new Player.Player(0,0);


        public int PlayerKills
        {
            get => playerKills;
            set => playerKills = value;
        }

        public GameOverMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(x, y, mediator, gameTime)
        {
            
            
        }

        public void stats()
        {
            
            stateObjects.Clear();
            MenuBackground();
            stateObjects.Add(new TextField(50, 50, this.mediator, "YOU HAVE DIED", Color.Yellow));
            stateObjects.Add(new TextField(50, 100, this.mediator, "KILLS: " + player.Kills, Color.Yellow));
            stateObjects.Add(new TextField(50, 150, this.mediator, "LEVELS COMPLETED: " + player.LevelsCompleted, Color.Yellow));


            stateObjects.Add(new Cursor());
        }

       
    }
}
