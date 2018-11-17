using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class UnitView:MonoBehaviour
    {
        public GameUnit Unit;
        public Vector3 Velocity;
        public Animator Animator;
        public Vector3 Offset;
        public float CurrentDirection;

        public void Update()
        {
            transform.position = Unit.transform.position + Offset;

            if (Game.GameTime.IsOnPause)
            {
                Animator.speed = 0f;
            }
            else
            {
                Animator.speed = 1f;
            }

            Vector3 reletiveVelocity = transform.InverseTransformVector(Velocity);

            Animator.SetFloat("Move", reletiveVelocity.x);
            Animator.SetFloat("Strafe", reletiveVelocity.z);

            Rotate();

            CurrentDirection = Vector3.SignedAngle(Vector3.forward, transform.forward,Vector3.up);
        }

        Vector2 RotateVector(Vector2 point, float angle)
        {
            Vector2 rotatedPoint;
            rotatedPoint.x = point.x * Mathf.Cos(angle) - point.y * Mathf.Sin(angle);
            rotatedPoint.y = point.x * Mathf.Sin(angle) + point.y * Mathf.Cos(angle);
            return rotatedPoint;
        }

        private void Rotate()
        {
            if (Game.GameTime.IsOnPause)
                return;

            transform.rotation =  Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(Unit.Direction, Vector3.up),Time.deltaTime*Unit.RotationSpeed);
        }
    }
}