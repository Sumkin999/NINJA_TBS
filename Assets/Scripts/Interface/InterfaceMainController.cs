using Assets.Scripts.GameMechanic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class InterfaceMainController:MonoBehaviour
    {
        public Image PauseImage;

        public void PauseImageVisibility(bool isPaused)
        {
            PauseImage.gameObject.SetActive(isPaused);
        }

        public void Update()
        {
            PauseImageVisibility(Game.GameTime.IsOnPause);
        }
    }
}
