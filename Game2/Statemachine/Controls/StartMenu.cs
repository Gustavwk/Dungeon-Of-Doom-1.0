using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.gameLogic.HUD_Objects;
using Game2.Statemachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Game2.gameLogic.IDrawable;
using IUpdateable = Game2.gameLogic.IUpdateable;

namespace Game2.Menus.Controls
{
    class StartMenu : StateHolder

    {
        
     

        public StartMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(x,y,mediator,gameTime)
        {
            this.mediator = mediator;
            this.x = x;
            this.y = y;
            initMenu();
        }

       

        public void initMenu()
        {
            MenuBackground();

            stateObjects.Add(new TextField( 50, 100, mediator, "WELCOME TO THE GAME, HAS YET TO BE NAMED", Color.Yellow));
            stateObjects.Add(new PlayButton(400-100, 150,mediator,"Play"));
            stateObjects.Add(new ExitButton(400-100, 350, mediator, "Exit"));
            stateObjects.Add(new Cursor());
           
        }

        
    }
}
