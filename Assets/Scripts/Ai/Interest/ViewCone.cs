using System.Collections.Generic;
using Assets.Scripts.Ai.Brain;
using UnityEngine;

namespace Assets.Scripts.Ai.Interest
{
    public class ViewCone:MonoBehaviour
    {
        public float RayDistance = 1f;
        public float RayRadius = 5f;
        private BrainBase brain;
        private AddGoalClass addGoalClass;
        private List<InterestSpawner> targets = new List<InterestSpawner>();

        public void SetAddGoalClass(BrainBase newBrain,AddGoalClass newAddGoalClass)
        {
            brain = newBrain;
            addGoalClass = newAddGoalClass;
        }

        void Update()
        {
            if (brain == null)
                return;

            Vector3 rayFrom = transform.position;
            Ray ray = new Ray(rayFrom, transform.forward);
            RaycastHit[] hits = Physics.SphereCastAll(ray, RayRadius,RayDistance);

            Debug.DrawLine(rayFrom, rayFrom + transform.forward);         

            List<InterestSpawner> tempTargets = new List<InterestSpawner>();

            foreach (var hit in hits)
            {
                InterestSpawner interestSpawner = hit.collider.GetComponent<InterestSpawner>();
                if (interestSpawner == null)
                    continue;

                tempTargets.Add(interestSpawner);
                if (!targets.Contains(interestSpawner))
                {
                    targets.Add(interestSpawner);
                }
            }

            if (!brain.IsAggredByBot)
            {
                foreach (var target in targets)
                {
                    if (!tempTargets.Contains(target))
                    {
                        OnRemoveTarget(target);
                    }
                }
            }
            

            targets = tempTargets;

            foreach (var target in targets)
            {
                target.SpawnPlayerInterest(brain);

                brain.AggroOthers(target);
            }
        }

        private void OnRemoveTarget(InterestSpawner interestSpawner)
        {
            interestSpawner.RemovePlayerInterest(brain);

            if (addGoalClass == null)
            {
                return;
            }
            addGoalClass.AddMoveAtomGoal(interestSpawner.transform.position);
        }

    }
}
