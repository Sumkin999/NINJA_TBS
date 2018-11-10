using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class UnitView:MonoBehaviour
    {
        private GameUnit unit;
        public Vector3 Velocity;
        public Animator Animator;

        public void Start()
        {
            unit = GetComponentInParent<GameUnit>();
        }

        public void Update()
        {
            if (Game.GameTime.IsOnPause)
            {
                Animator.speed = 0f;
            }
            else
            {
                Animator.speed = 1f;
            }
            transform.rotation = Quaternion.AngleAxis(unit.Direction,Vector3.up);
            Animator.SetFloat("Move",-Velocity.x);
            Animator.SetFloat("Strafe", -Velocity.z);
        }
    }
}