using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Visuals
{
    public class MainParticleController:MonoBehaviour
    {
        public GameObject BloodParticlePrefab;
        public void SpawnParticleBlood(Vector3 spawnPosition)
        {
            GameObject.Instantiate(BloodParticlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
