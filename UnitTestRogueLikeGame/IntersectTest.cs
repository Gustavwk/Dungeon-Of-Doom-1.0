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
using Game2.Items;
using Game2.Items.Weapons;
using Game2.Menus.Controls;
using Game2.Menus.States;
using Game2.Structures;
using Items;

namespace Game2.Tests
{
    [TestClass()]
    public class GameObjectTests
    {
        private Mediator testMediator;
        private Player.Player testPlayer;
        private Wall testWall;
        private Monster testMonster;
        private Monster testMonster2;
        private List<GameObject> allObject;     
        private List<GameObject> itemToBeAdded;
        private List<GameObject> itemToBeDeleted;
        private ActualGameState TestState;
        private GameMain TestGame;
        private HpBoost testHpBoost;
        private int ExpectedHp;
        private int HpPlus;
        private MsBoost testMSBoost;
        int ExpectedMs;
        private Wand testWand;
        private FrozenBow testBow;
        private SimpleGun testGun;
        private Crossbow testCrossbow;
        private LavaTile testLaveTile;
        private Door testDoor;
        private Room testRoom;
        private CrossbowProjectile CBProjectile;
        private SimpleGunProjectile SGProjectile;
        private WandProjectile WProjectile;
        private FrozenBowProjectile FBProjectile;
       



        [TestInitialize]
        public void TestInitialize()
        {

            itemToBeAdded = new List<GameObject>();
            itemToBeDeleted = new List<GameObject>();
            allObject = new List<GameObject>();
            testPlayer = new Player.Player(200, 200);
            testMediator = new Mediator(allObject, itemToBeAdded, itemToBeDeleted, testPlayer, testRoom, TestState);
            testRoom = new Room(800,400,testMediator);
            testMediator.room = testRoom;
            testWall = new Wall(200,200,testMediator);
            testMonster = new Creep.Creep(200,200,testMediator);
            testMonster2 = new Creep.Creep(200, 200, testMediator);
            HpPlus = 100;
            testHpBoost = new HpBoost(HpPlus, 200, 200, testMediator);
            testMSBoost = new MsBoost(200, 200, testMediator);
            ExpectedMs = testMSBoost.SpeedBoost;
            testCrossbow = new Crossbow(200, 200, testMediator);
            testBow = new FrozenBow(200, 200, testMediator);
            testGun = new SimpleGun(200, 200, testMediator);
            testWand = new Wand(200, 200, testMediator);
            testLaveTile = new LavaTile(200,200,5,testMediator);
            testDoor = new Door(200,200,testMediator,true);
            FBProjectile = new FrozenBowProjectile(200,200,Direction.NORTH,testMediator);
            WProjectile = new WandProjectile(200, 200, Direction.NORTH, testMediator);
            SGProjectile = new SimpleGunProjectile(200, 200, Direction.NORTH, testMediator);
            CBProjectile = new CrossbowProjectile(200, 200, Direction.NORTH, testMediator);


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
            Assert.IsTrue(testMonster.hitbox.Intersects(testPlayer.hitbox));
            testMonster.intersects(testPlayer);
            int expected = testPlayer.health;
            int actual = 99;
            Assert.AreEqual(expected,actual);
           
        }

        [TestMethod()]
        public void PlayerPickUpHPBoost()
        {
            ExpectedHp = testPlayer.health + HpPlus;
            Assert.IsTrue(testHpBoost.hitbox.Intersects(testPlayer.hitbox));
            testHpBoost.intersects(testPlayer);
            int actualHp = testPlayer.health; 
            Assert.AreEqual(ExpectedHp, actualHp);
          
        }

        [TestMethod()]
        public void PlayerPickUpMSBoost()
        {
            Assert.IsTrue(testMSBoost.hitbox.Intersects(testPlayer.hitbox));
            testMSBoost.intersects(testPlayer);
            testMSBoost.EffectForDuration();
            int actualMs = testPlayer.movementspeed;      
            Assert.AreEqual(ExpectedMs, actualMs);
   
        }

        [TestMethod()]
        public void PlayerPickUpWand()
        {
            Assert.IsTrue(testWand.hitbox.Intersects(testPlayer.hitbox));
            testWand.intersects(testPlayer);
            Assert.IsTrue(testPlayer.weapon is Wand);

        }

        [TestMethod()]
        public void PlayerPickUpFrozenBow()
        {
            Assert.IsTrue(testBow.hitbox.Intersects(testPlayer.hitbox));
            testBow.intersects(testPlayer);
            Assert.IsTrue(testPlayer.weapon is FrozenBow);
        }
        [TestMethod()]
        public void PlayerPickUpSimpleGun()
        {

            Assert.IsTrue(testGun.hitbox.Intersects(testPlayer.hitbox));
            testGun.intersects(testPlayer);
            Assert.IsTrue(testPlayer.weapon is SimpleGun);
        }

        [TestMethod()]
        public void PlayerPickUpCrossBow()
        {
            Assert.IsTrue(testCrossbow.hitbox.Intersects(testPlayer.hitbox));
            testCrossbow.intersects(testPlayer);
            Assert.IsTrue(testPlayer.weapon is Crossbow);

        }

        [TestMethod()]
        public void PlayerIntersectLava()
        {
            Assert.IsTrue(testLaveTile.hitbox.Intersects(testPlayer.hitbox));
            testLaveTile.LastStir = 500;
            testLaveTile.intersects(testPlayer);
            int expectedHp = testPlayer.health;
            int actualHp = testPlayer.health-1;
            Assert.AreEqual(expectedHp, actualHp);


        }

        [TestMethod()]
        public void PlayerIntersectDoor()
        {
            Assert.IsTrue(testDoor.hitbox.Intersects(testPlayer.hitbox));

            int levelsExpectedToBeCompleted = testPlayer.LevelsCompleted + 1;
            testDoor.intersects(testPlayer);
            int levelsActuallyCompleted = testPlayer.LevelsCompleted;

            Assert.AreEqual(levelsExpectedToBeCompleted,levelsActuallyCompleted);
        }

        [TestMethod()]
        public void CreepIntersectWall()
        {
            Assert.IsTrue(testMonster.hitbox.Intersects(testWall.hitbox));         
        }

        [TestMethod()]
        public void CreepIntersectCreep()
        {
            Assert.IsTrue(testMonster.hitbox.Intersects(testMonster2.hitbox));

        }

        [TestMethod()]
        public void CreepIntersectCBProjectil()
        {
            Assert.IsTrue(CBProjectile.hitbox.Intersects(testMonster.hitbox));
            int expectedHp = testMonster.Health - CBProjectile.Damage;
            CBProjectile.intersects(testMonster);
            int actualHp = testMonster.Health;
            Assert.AreEqual(expectedHp,actualHp);

        }
        [TestMethod()]
        public void CreepIntersectWProjectil()
        {
            Assert.IsTrue(WProjectile.hitbox.Intersects(testMonster.hitbox));
            int expectedHp = testMonster.Health - WProjectile.Damage;
            WProjectile.intersects(testMonster);
            int actualHp = testMonster.Health;
            Assert.AreEqual(expectedHp, actualHp);
        }
        [TestMethod()]
        public void CreepIntersectFBProjectil()
        {
            Assert.IsTrue(FBProjectile.hitbox.Intersects(testMonster.hitbox));
            int expectedHp = testMonster.Health - FBProjectile.Damage;
            FBProjectile.intersects(testMonster);
            int actualHp = testMonster.Health;
            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestMethod()]
        public void CreepIntersectSGProjectil()
        {
            Assert.IsTrue(SGProjectile.hitbox.Intersects(testMonster.hitbox));
            int expectedHp = testMonster.Health - SGProjectile.Damage;
            SGProjectile.intersects(testMonster);
            int actualHp = testMonster.Health;
            Assert.AreEqual(expectedHp, actualHp);
        }


    }
}