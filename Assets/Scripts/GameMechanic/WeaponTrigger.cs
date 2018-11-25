using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class WeaponTrigger:MonoBehaviour
    {
        public GameUnit Caster;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Caster.gameObject)
                return;

            if (other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                GameUnit enemyGameUnit = other.GetComponent<GameUnit>();
                Triggered(enemyGameUnit);

                //Game.MainParticleController.SpawnParticleBlood(other.ClosestPointOnBounds(transform.position));
            }
        }

        public void Triggered(GameUnit enemy)
        {
            UnitCommandController unitCommandController = Caster.GetComponent<UnitCommandController>();

            if (unitCommandController == null)
                return;

            if (unitCommandController.CurrentCommand == null)
                return;

            unitCommandController.CurrentCommand.OnWeaponnTriggeredEnemy(enemy);
        }

    }
}