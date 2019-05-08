using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.gameLogic.HUD_Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures 
{
    class Door : Structures
    {
        private Texture2D defaultDoor;
        private int level;
        private bool isOpen;


        public Door(int x, int y, Mediator mediator, bool isOpen) : base(mediator,x,y)
        {
            this.isOpen = isOpen;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);

           

        }
        public override void Load()
        {
            defaultDoor = Mediator.Game.Content.Load<Texture2D>("Doors/closed_door");
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public bool removeRoom(List<GameObject> items)
        {
            foreach (GameObject item in items)
            {
                items.Remove(item);
            }
            return true;
        }


        public int levelUp(List<GameObject> itemToBeAdded)
        {
           

            
            
            return level++;
        }

        public override bool intersects(GameObject other) //Er der en grund til at det er GameObject other og ikke GameObject other ligesom de andre?
        {
            
            if (other is Player.Player)
            {
                Player.Player p = (Player.Player)other;
                if (this.isOpen == true)
                {
                  
                    foreach (var gameObject in mediator.AllObjects)
                    {
                        if (gameObject is Player.Player || gameObject is HUDTile ||
                              gameObject is HUD)
                        {
                           // do nothing
                        }
                        else
                        {
                            mediator.itemToBeDeleted.Add(gameObject);
                        }
                    }
                    
                    p.setX(unitCoord(1));
                    p.setY(unitCoord(7));
                    mediator.room.initRandomLevel();
                    mediator.itemToBeAdded.Add(mediator.player); 
                    mediator.itemToBeDeleted.Add(mediator.player);
                }
               
           
            }
            return true;

        }

        public int unitCoord(int coord) //den her er translater et coordinat så det giver mening i forhold til vores units !
        {
            int unitCoord = coord * unit;
            return unitCoord;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultDoor, hitbox, Color.White);

        }
    }
}
