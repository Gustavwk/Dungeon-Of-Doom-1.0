using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.gameLogic.HUD_Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Game2.gameLogic.IDrawable;
using IUpdateable = Game2.gameLogic.IUpdateable;

namespace Game2.Menus.Controls
{
    class Menu

    {
        
        private Mediator mediator;
        private List<GameObject> menuObjects =  new List<GameObject>();
        private int x;
        private int y;
        private int unit = 32;


        public Menu(int x, int y, Mediator mediator)
        {
            this.mediator = mediator;
            this.x = x;
            this.y = y;
            initMenu();
        }

        public List<GameObject> MenuObjects
        {
            get => menuObjects;
            set => menuObjects = value;
        }

        public void initMenu()
        {
            MenuBackground();
            menuObjects.Add(new PlayButton(400,200,mediator,"Play"));
            menuObjects.Add(new Button(400, 300, mediator, "Exit"));
        }

        private void MenuBackground()
        {
            Random random = new Random();

            for (int i = 0; i < this.x; i += unit)
            {
                for (int j = 0; j < this.x; j += unit)
                {
                    menuObjects.Add(new HUDTile(i, j, random.Next(5), this.mediator));
                }
            }
        }
    }
}
