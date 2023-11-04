using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace roundbeargames_tutorial
{

    public enum TransitionHandParameter
    {
        Rock,
        Scissor,
        Paper,
    }
    public class HandControl : MonoBehaviour
    {
        public Animator animator;
        private CharacterControl control;
        private ECharacterControl econtrol;
        private GameObject player;
        private void Awake()
        {
            control = animator.GetComponentInParent<CharacterControl>();
            player = GameObject.Find("Enemy");
            econtrol = player.GetComponent<ECharacterControl>();
        }
        private void Update()
        {

            if (control.Rock && econtrol.Reveal)
            {
                animator.SetBool(TransitionHandParameter.Rock.ToString(), true);
                animator.SetBool(TransitionHandParameter.Paper.ToString(), false);
                animator.SetBool(TransitionHandParameter.Scissor.ToString(), false);
            }
            else
            {
                animator.SetBool(TransitionHandParameter.Rock.ToString(), false);
            }
            if (control.Paper && econtrol.Reveal)
            {
                animator.SetBool(TransitionHandParameter.Paper.ToString(), true);
                animator.SetBool(TransitionHandParameter.Rock.ToString(), false);
                animator.SetBool(TransitionHandParameter.Scissor.ToString(), false);

            }
            else
            {
                animator.SetBool(TransitionHandParameter.Paper.ToString(), false);
            }
            if (control.Scissors && econtrol.Reveal)
            {
                animator.SetBool(TransitionHandParameter.Scissor.ToString(), true);
                animator.SetBool(TransitionHandParameter.Paper.ToString(), false);
                animator.SetBool(TransitionHandParameter.Rock.ToString(), false);
            }
            else
            {
                animator.SetBool(TransitionHandParameter.Scissor.ToString(), false);
            }

            if ((control.Rock && econtrol.Rock) || (control.Paper && econtrol.Paper) || (control.Scissors && econtrol.Scissors))
            {
                control.draw = true;
            }
            if ((control.Rock && econtrol.Scissors) || (control.Scissors && econtrol.Paper) || (control.Paper && econtrol.Rock))
            {
                control.win = true;
            }
            if ((econtrol.Rock && control.Scissors) || (econtrol.Scissors && control.Paper) || (econtrol.Paper && control.Rock))
            {
                control.lose = true;
            }

        }


    }

}

