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

            if (Vector2.Distance(new Vector2(Destination.x,Destination.z), new Vector2(Target.transform.position.x, Target.transform.position.z))<0.1f)
            {
                //TODO Доделать нормальный комплит перемещения
                //CompleteCommand();
            }
        }

        public override void StopCommand()
        {
            Target.StopMove();
        }
    }
}
