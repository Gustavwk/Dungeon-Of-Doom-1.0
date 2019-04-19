using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Structures;

namespace Game2.gameLogic
{
    class Mediator
    {
        public static GameMain Game { get; set; }

        public List<GameObject> AllObjects { get; }
        public List<GameObject> itemToBeAdded { get; }

        public Player.Player player { get; }
        public Creep.Creep creep { get; }
        public GameObject room { get; }

        public Mediator(List<GameObject> allObjects, List<GameObject> itemToBeAdded, Player.Player player, Room room, Creep.Creep creep)
        {
            this.AllObjects = allObjects;
            this.itemToBeAdded = itemToBeAdded;
            this.player = player;
            this.creep = creep;
            this.room = room;
        }
    }
}
