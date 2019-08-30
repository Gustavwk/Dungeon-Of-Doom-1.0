﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.gameLogic
{
    interface IPowerUp
    {
        void PlayerInteraction(GameObject other);
        void EffectForDuration();
    }
}
