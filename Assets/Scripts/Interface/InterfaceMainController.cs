using Assets.Scripts.GameMechanic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class InterfaceMainController:MonoBehaviour
    {
        public Image PauseImage;

        public Slider HealthSlider;

        public GameObject MoveTargetGameObject;
        public GameObject AttackTargetGameObject;


        public void Start()
        {
            Game.InterfaceMainController = this;
        }
        public void Update()
        {
            PauseImageVisibility(Game.GameTime.IsOnPause);
            UpdateHealthSlider();
            PlayerTargetControl();
        }



        public void PauseImageVisibility(bool isPaused)
        {
            PauseImage.gameObject.SetActive(isPaused);
        }

        public void UpdateHealthSlider()
        {
            HealthSlider.value = Game.PlayerUnit.Health/HealthSlider.maxValue;
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
