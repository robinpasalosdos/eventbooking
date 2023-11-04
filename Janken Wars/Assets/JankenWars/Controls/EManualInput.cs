using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class EManualInput : MonoBehaviour
    {
        private ECharacterControl characterControl;

        private void Awake()
        {
            characterControl = this.gameObject.GetComponent<ECharacterControl>();
        }

        void Update()
        {
            if (!characterControl.Meet && !characterControl.hole && !characterControl.win)
            {
                if (EVirtualInputManager.Instance.MoveRight)
                {
                    characterControl.MoveRight = true;
                }
                else
                {
                    characterControl.MoveRight = false;
                }

                if (EVirtualInputManager.Instance.MoveLeft)
                {
                    characterControl.MoveLeft = true;
                }
                else
                {
                    characterControl.MoveLeft = false;
                }

                if (EVirtualInputManager.Instance.Jump)
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
                if (EVirtualInputManager.Instance.Rock)
                {
                    characterControl.Rock = true;
                    characterControl.Scissors = false;
                    characterControl.Paper = false;
                    characterControl.Reveal = true;
                }

                if (EVirtualInputManager.Instance.Scissors)
                {
                    characterControl.Scissors = true;
                    characterControl.Paper = false;
                    characterControl.Rock = false;
                    characterControl.Reveal = true;
                }

                if (EVirtualInputManager.Instance.Paper)
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