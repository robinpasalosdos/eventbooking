using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace roundbeargames_tutorial
{
    public class BGSound : MonoBehaviour
    {

        public GameObject soundsObject;
        public AudioSource BGMusic;
        public AudioSource BGMusicClose;
        public AudioSource Victory;
        public bool victory;
        private void Update()
        {
            GameObject player = GameObject.Find("SuitedMan");
            CharacterControl control = player.GetComponent<CharacterControl>();
            GameObject eplayer = GameObject.Find("Enemy");
            ECharacterControl econtrol = eplayer.GetComponent<ECharacterControl>();
            BgmControl sounds = soundsObject.GetComponent<BgmControl>();
 
            if (control.Meet && econtrol.Meet)
            {
                if (!BGMusicClose.isPlaying)
                {
                    BGMusicClose.Play();
                }
                BGMusic.Stop();

            }
            else
            {
                if (!Victory.isPlaying)
                {
                    BGMusicClose.Stop();
                    if (!BGMusic.isPlaying)
                    {
                        BGMusic.Play();
                    }
                }

            }

            if (Victory.isPlaying)
            {
                victory = true;
            }

            if (((control.victory && !control.Meet) || (econtrol.victory && !econtrol.Meet)) && !victory)
            {
                Victory.Play();
                BGMusic.Stop();
            }
            
        }
    }
}
