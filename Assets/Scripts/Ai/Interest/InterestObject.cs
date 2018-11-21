using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
    }

    public class PlayerPositionInterestObject : InterestObject
    {
        
    }
}
