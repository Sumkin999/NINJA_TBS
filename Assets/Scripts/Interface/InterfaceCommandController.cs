using Assets.Scripts.GameMechanic;
using Assets.Scripts.Interface.InterfaceCommand;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class InterfaceCommandController:MonoBehaviour
    {
        private BaseInterfaceCommand currentCommand;

        void Start()
        {
            
        }

        void Update()
        {
            if (currentCommand != null)
            {
                currentCommand.Update();
            }

            LeftClickHolder();
            SpaceDownHolder();
        }

        public void SelectCommand(BaseInterfaceCommand newCommand)
        {
            currentCommand = newCommand;
            currentCommand.Start();
        }

        public void LeftClickHolder()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray =  UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    SelectCommand(new InterfaceCommandMove(hit.point));
                }
            }
        }

        public void SpaceDownHolder()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Game.GameTime.SwitchPause();
            }
        }
    }
}