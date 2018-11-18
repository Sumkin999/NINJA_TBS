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
            IsOnPause = !IsOnPause;
        }
    }
}
