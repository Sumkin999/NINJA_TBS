using AuraAPI;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class WeatherController:MonoBehaviour
    {
        public AuraVolume AuraVolumeSphere;
        public AuraVolume AuraVolumeGlobal;

        void Start()
        {
            AuraVolumeSphere.enabled = true;
            AuraVolumeGlobal.enabled = true;
        }
    }
}