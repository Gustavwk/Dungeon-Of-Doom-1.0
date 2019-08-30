using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;

namespace Game2.Menus.States
{
    public class ActualGameState: IMediator
    {
        private GameState gameState;

        public ActualGameState(GameState state)
        {
            this.State = state;
        }
  
        public GameState State 
        {
            get => gameState;
            set => gameState = value;
        }

        public Mediator mediator { get; set; }
    }
}
