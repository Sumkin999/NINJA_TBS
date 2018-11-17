using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class GameTime : MonoBehaviour
    {


        public bool IsOnPause {get; private set; }

        public void PauseGame()
        {
            IsOnPause = true;
        }

        public void UnpauseGame()
        {
            IsOnPause = false;
        }

        public void SwitchPause()
        {
            if (IsOnPause)
            {
                IsOnPause = false;
            }
            else
            {
                IsOnPause = true;
            }
        }

        // Use this for initialization
        void Start ()
        {
		
        }
	
        // UpdateCommand is called once per frame
        void Update ()
        {
		
        }
    }
}
