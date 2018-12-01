using AuraAPI;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class WeatherController:MonoBehaviour
    {
        public AuraVolume AuraVolumeSphere;
        public AuraVolume AuraVolumeGlobal;
        public AuraLight Light;
        public Aura Camera;

        void Start()
        {
            AuraVolumeSphere.enabled = true;
            AuraVolumeGlobal.enabled = true;
            Light.enabled = true;
            Camera.enabled = true;
        }
    }
}