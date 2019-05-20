using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Creeps;
using Game2.gameLogic;
using Game2.Menus.Controls;
using Game2.Menus.States;
using Game2.Structures;

namespace Game2.Tests
{
    [TestClass()]
    public class GameObjectTests
    {
        private Mediator testMediator;
        private Player.Player testPlayer;
        private Wall testWall;
        private Monster testMonster;
        private List<GameObject> allObject;
        
        private List<GameObject> itemToBeAdded;
        private List<GameObject> itemToBeDeleted;
        private ActualGameState TestState;
       
        public Room testRoom;



        [TestInitialize]
        public void TestInitialize()
        {

            itemToBeAdded = new List<GameObject>();
            itemToBeDeleted = new List<GameObject>();
            allObject = new List<GameObject>();
            testMediator = new Mediator(allObject, itemToBeAdded, itemToBeDeleted, testPlayer, testRoom, TestState);
            testRoom = new Room(800,400,testMediator);
            testPlayer = new Player.Player(200, 200);
            testWall = new Wall(200,200,testMediator);
            testMonster = new Creep.Creep(200,200,testMediator);
           



         
        }

        [TestMethod()]
        public void PlayerIntersectsWallTrue()
        {
            Assert.IsTrue(testPlayer.hitbox.Intersects(testWall.hitbox));
        }

        [TestMethod()]
        public void PlayerIntersectsWallFalse()
        {
            testPlayer.hitbox.X = 0;
            testPlayer.hitbox.Y = 0;
            Assert.IsFalse(testPlayer.hitbox.Intersects(testWall.hitbox));

        }
        [TestMethod()]
        public void PlayerIntersectsWithCreep()
        {
            testMonster.intersects(testPlayer);

            int expected = testPlayer.health;
            int actual = 99;
            Assert.AreEqual(expected,actual);


        }

        [TestMethod()]
        public void PlayerPickUpASBoost()
        {


        }

        [TestMethod()]
        public void PlayerPickUpMSBoost()
        {


        }

        [TestMethod()]
        public void PlayerPickUpWand()
        {


        }

        [TestMethod()]
        public void PlayerPickUpFrozenBow()
        {


        }
        [TestMethod()]
        public void PlayerPickUpSimpleGun()
        {


        }

        [TestMethod()]
        public void PlayerIntersectLava()
        {


        }

        [TestMethod()]
        public void PlayerIntersectDoor()
        {


        }

        [TestMethod()]
        public void CreepIntersectWall()
        {


        }

        [TestMethod()]
        public void CreepIntersectCreep()
        {


        }


    }
}