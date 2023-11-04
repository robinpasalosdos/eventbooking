using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class Cap : MonoBehaviour
    {
        public GameObject cap;
        private void Awake()
        {
            cap.SetActive(false);
        }
        private void Update()
        {
            GameObject player = GameObject.Find("SuitedMan");
            CharacterControl control = player.GetComponent<CharacterControl>();
            GameObject eplayer = GameObject.Find("Enemy");
            ECharacterControl econtrol = eplayer.GetComponent<ECharacterControl>();
            if (control.Meet && econtrol.Meet)
            {
                cap.SetActive(true);
            }
            if((!control.Meet && control.duration > 2.2f) || (!econtrol.Meet && econtrol.duration > 2.2f))
            {
                cap.SetActive(false);
            }
        }
    }
}
