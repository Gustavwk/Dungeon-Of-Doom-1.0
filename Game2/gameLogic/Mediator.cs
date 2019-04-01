﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Structures;

namespace Game2.gameLogic
{
    class Mediator
    {
        public List<GameObject> AllObjects { get; }
        public Player.Player Player1 { get; }
        public Room Room1 { get; }

        public Mediator(List<GameObject> allObjects, Player.Player player, Room room)
        {
            this.AllObjects = allObjects;
            this.Player1 = player;
            this.Room1 = room;
        }
    }
}