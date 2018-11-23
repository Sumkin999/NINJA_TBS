using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Ai.Interest
{
    public class InterestObject
    {
        public bool IsComplteted;

        public virtual bool IsEqual(InterestObject interestObject)
        {
            return false;
        }

        public virtual int GetInterestValue()
        {
            return 100;
        }
    }

    public class PlayerInterestObject : InterestObject
    {
        public PlayerInterestObject(GameUnit gameUnitLocal)
        {
            Unit = gameUnitLocal;
        }
        public GameUnit Unit { get; private set; }

        public override bool IsEqual(InterestObject interestObject)
        {
            PlayerInterestObject playerInterestObject=interestObject as PlayerInterestObject;

            if (playerInterestObject==null)
            {
                return false;
            }

            if (playerInterestObject.Unit==Unit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

 
    
}
