using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public static class AudioFadeOut
    {

        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }


         public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)

         {
           float startVolume = audioSource.volume;

           while (audioSource.volume < 0.8f)
           {
               audioSource.volume += startVolume * Time.deltaTime / FadeTime;

               yield return null;
           }

           
        audioSource.volume = 0.8f;
    }


    }
