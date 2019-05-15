using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Menus.Controls;
using Game2.Menus.States;
using Game2.Structures;

namespace Game2.gameLogic
{
    class Mediator
    {
        public static GameMain Game { get; set; }
        public List<GameObject> AllObjects { get; }
        public List<GameObject> itemToBeAdded { get; }
        public List<GameObject> itemToBeAddedButDrawnLast { get; }
        public List<GameObject> itemToBeDeleted { get; }
        public ActualGameState State { get;set; }
        public GameOverMenu gameOverMenu { get; set; }

        public Player.Player player { get; }
        public Room room { get; set; }

        public Mediator(List<GameObject> allObjects, List<GameObject> itemToBeAdded, List<GameObject> itemToBeDeleted , List<GameObject> itemToBeAddedButDrawnLast, Player.Player player, Room room, ActualGameState actual)
        {
            this.AllObjects = allObjects;
            this.itemToBeAdded = itemToBeAdded;
            this.itemToBeAddedButDrawnLast = itemToBeAddedButDrawnLast;
            this.itemToBeDeleted = itemToBeDeleted;
            this.player = player;
            this.room = room;
            this.State = actual;
            
        }
    }
}
