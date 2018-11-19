using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundComponent:MonoBehaviour
    {
        public AudioSource AudioSource;

        public bool IsSoundPlaying { get; private set; }

        public void Update()
        {
            IsSoundPlaying = AudioSource.isPlaying;
        }
        public void Play()
        {
            AudioSource.Play();
        }

        public void Stop()
        {
            AudioSource.Stop();
        }
    }
}
