using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Creeps
{
    class BossGhost : GameObject


    {
        private Texture2D undamgedRight;
        private Texture2D undamgedLeft;
        private Texture2D damgedRight;
        private Texture2D damgedLeft;
        private Texture2D damgedBack;
        private Texture2D undamgedBack;

        public BossGhost(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, 96, 96);
            this.priority = 5;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
          
        }

        public override void Load()
        {
            this.damgedLeft = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost damaged");
            this.damgedRight = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost damaged flipped");
            this.damgedBack = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost back damaged");
            this.undamgedLeft = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost");
            this.undamgedRight = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost reversed");
            this.undamgedBack = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost back");
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override bool intersects(GameObject other)
        {
            return true;
        }

    }
   
}
