using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundComponent:MonoBehaviour
    {
        public AudioSource AudioSource;

        public bool IsSoundPlaying { get; private set; }
        public List<AudioClip> AudioClips=new List<AudioClip>();

        public void Update()
        {
            

            if (Game.GameTime.IsOnPause)
            {
                if (IsSoundPlaying)
                {
                    if (AudioSource.isPlaying)
                    {
                        AudioSource.Pause();
                    }
                    
                }
            }
            else
            {
                IsSoundPlaying = AudioSource.isPlaying;
                if (IsSoundPlaying)
                {
                    if (!AudioSource.isPlaying)
                    {
                        AudioSource.Play();
                    }

                }
            }
        }
        public void Play()
        {
            AudioSource.Stop();
            int r = UnityEngine.Random.Range(0, AudioClips.Count-1);
            AudioSource.clip = AudioClips[r];
            AudioSource.Play();
        }
        

        public void Stop()
        {
            AudioSource.Stop();
        }
    }
}
