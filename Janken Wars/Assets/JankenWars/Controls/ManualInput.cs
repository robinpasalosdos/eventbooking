using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;
        

        private void Awake()
        {
            characterControl = this.gameObject.GetComponent<CharacterControl>();

        }

        void Update()
        {
            if (!characterControl.Meet && !characterControl.hole && !characterControl.win) 
            { 
                if (VirtualInputManager.Instance.MoveRight)
                {
                    characterControl.MoveRight = true;
                }
                else
                {
                    characterControl.MoveRight = false;
                }

                if (VirtualInputManager.Instance.MoveLeft)
                {
                    characterControl.MoveLeft = true;
                }
                else
                {
                    characterControl.MoveLeft = false;
                }

                if (VirtualInputManager.Instance.Jump)
                {
                    characterControl.Jump = true;
                }
                else
                {
                    characterControl.Jump = false;
                }
            }
            if (characterControl.Meet && !characterControl.Reveal)
            {
                if (VirtualInputManager.Instance.Rock)
                {
                    characterControl.Rock = true;
                    characterControl.Scissors = false;
                    characterControl.Paper = false;
                    characterControl.Reveal = true;
                    

                }

                if (VirtualInputManager.Instance.Scissors)
                {
                    characterControl.Scissors = true;
                    characterControl.Paper = false;
                    characterControl.Rock = false;
                    characterControl.Reveal = true;
                  
         
                }

                if (VirtualInputManager.Instance.Paper)
                {
                    characterControl.Paper = true;
                    characterControl.Rock = false;
                    characterControl.Scissors = false;
                    characterControl.Reveal = true;
                   
                
                }

            }
        }
    }
}