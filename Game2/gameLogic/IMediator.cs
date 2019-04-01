using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.gameLogic
{
    interface IMediator : ICloneable // IMediiator implementerer nu iClonable, så vi kan klone objecter senere.
    {
        Mediator mediator { get; set; }
    }
}
