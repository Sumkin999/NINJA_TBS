using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using UnityEngine;

namespace Assets.Scripts.Ai.Interest
{
    public class InterestBrain
    {
        public InterestBrain(BrainBase brain)
        {
            Brain = brain;
        }
        public BrainBase Brain { get; private set; }

        public bool IsAggredByBotInterest;

        public InterestObject CurrentInterestObject;
        public List<InterestObject> InterestPoints = new List<InterestObject>();

        private int _currentMaxInterest;

        public void UpdateInterestObjects()
        {
            if (CurrentInterestObject != null)
            {
                _currentMaxInterest = CurrentInterestObject.GetInterestValue();
            }
            else
            {
                _currentMaxInterest = 0;
            }



            if (InterestPoints.Count > 0)
            {
                for (int i = InterestPoints.Count - 1; i >= 0; i--)
                {

                    if (InterestPoints[i].IsComplteted)
                    {

                        if (InterestPoints[i] == CurrentInterestObject)
                        {
                            CurrentInterestObject = null;
                        }
                        InterestPoints.RemoveAt(i);
                    }

                }
            }


            foreach (var interestObj in InterestPoints)
            {
                if (interestObj.GetInterestValue() > _currentMaxInterest)
                {
                    CurrentInterestObject = interestObj;
                    _currentMaxInterest = interestObj.GetInterestValue();
                }
            }

        }
    }
}
