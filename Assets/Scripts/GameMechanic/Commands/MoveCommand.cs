using UnityEngine;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class MoveCommand : BaseCommand
    {
        public Vector3 Destination;

        public MoveCommand(Vector3 destination, GameUnit target)
        {
            Destination = destination;
            Target = target;
        }

        public override void UpdateCommand()
        {
            Target.MoveTo(Destination);

            if (Vector2.Distance(Destination,new Vector2(Target.transform.position.x, Target.transform.position.z))<0.1f)
            {
                CompleteCommand();
            }
        }
    }
}
