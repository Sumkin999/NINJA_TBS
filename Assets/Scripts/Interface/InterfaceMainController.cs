using System.Collections.Generic;
using Assets.Scripts.GameMechanic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class InterfaceMainController:MonoBehaviour
    {
        public Image PauseImage;
        public Canvas Canvas;

        public Slider HealthSlider;
        public Slider StaminSlider;
        public GameObject EnemyHealthPrefab;

        public GameObject MoveTargetGameObject;
        public GameObject AttackTargetGameObject;

        public List<UnitView> Enemies = new List<UnitView>();


        public void Start()
        {
            Game.InterfaceMainController = this;

            foreach (var enemy in Game.Enemies)
            {
                OnNewEnemy(enemy.UnitView, Canvas);
            }
        }
        public void Update()
        {
            PauseImageVisibility(Game.GameTime.IsOnPause);
            UpdateHealthSlider();
            UpdateStaminaSlider();
            PlayerTargetControl();
        }

        public void OnNewEnemy(UnitView enemy,Canvas canvas)
        {
            Enemies.Add(enemy);
            GameObject healthGameObject = Instantiate(EnemyHealthPrefab);
            healthGameObject.transform.SetParent(Canvas.transform, false);
            EnemyHealth enemyHealth = healthGameObject.GetComponent<EnemyHealth>();
            enemyHealth.OffsetTransform = enemy.HealthOffset;
            enemyHealth.Canvas = canvas;
            enemyHealth.GameUnit = enemy.Unit;
        }



        public void PauseImageVisibility(bool isPaused)
        {
            PauseImage.gameObject.SetActive(isPaused);
        }

        public void UpdateHealthSlider()
        {
            HealthSlider.value = Game.PlayerUnit.Health/ Game.PlayerUnit.MaxHealth;
        }

        public void UpdateStaminaSlider()
        {
            
        }

        public void PlayerTargetControl()
        {

            if (Game.GameTime.IsOnPause)
            {
                if (Vector3.Distance(Game.PlayerUnit.transform.position,Game.PlayerUnit.GetDestination)>0.2f)
                {
                    MoveTargetGameObject.transform.position = Game.PlayerUnit.GetDestination;
                }
                else
                {
                    MoveTargetGameObject.transform.position = new Vector3(0, -10f, 0);
                }
            }
            else
            {
                if (Game.PlayerUnit.IsMoving)
                {
                    MoveTargetGameObject.transform.position = Game.PlayerUnit.GetDestination;
                }
                else
                {
                    MoveTargetGameObject.transform.position = new Vector3(0, -10f, 0);
                }
            }
            
            /**/

            if (Game.PlayerUnit.Target!=null)
            {
                AttackTargetGameObject.transform.position = 
                    new Vector3(Game.PlayerUnit.Target.transform.position.x,0.25f, Game.PlayerUnit.Target.transform.position.z);
            }
            else
            {
                AttackTargetGameObject.transform.position = new Vector3(0, -10f, 0);
            }
        }

        
    }
}
