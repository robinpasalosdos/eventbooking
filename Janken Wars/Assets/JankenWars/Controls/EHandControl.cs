using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace roundbeargames_tutorial
{
    public enum ETransitionHandParameter
    {
        ERock,
        EScissor,
        EPaper,
    }
    public class EHandControl : MonoBehaviour
    {
        public Animator animator;
        private ECharacterControl control;
        private CharacterControl econtrol;
        private GameObject player;

        private void Awake()
        {
            control = animator.GetComponentInParent<ECharacterControl>();
            player = GameObject.Find("SuitedMan");
            econtrol = player.GetComponent<CharacterControl>();
        }
        private void Update()
        {

            if (control.Rock && econtrol.Reveal)
            {
                animator.SetBool(ETransitionHandParameter.ERock.ToString(), true);
                animator.SetBool(ETransitionHandParameter.EPaper.ToString(), false);
                animator.SetBool(ETransitionHandParameter.EScissor.ToString(), false);
            }
            else
            {
                animator.SetBool(ETransitionHandParameter.ERock.ToString(), false);
            }
            if (control.Paper && econtrol.Reveal)
            {
                animator.SetBool(ETransitionHandParameter.EPaper.ToString(), true);
                animator.SetBool(ETransitionHandParameter.ERock.ToString(), false);
                animator.SetBool(ETransitionHandParameter.EScissor.ToString(), false);

            }
            else
            {
                animator.SetBool(ETransitionHandParameter.EPaper.ToString(), false);
            }
            if (control.Scissors && econtrol.Reveal)
            {
                animator.SetBool(ETransitionHandParameter.EScissor.ToString(), true);
                animator.SetBool(ETransitionHandParameter.EPaper.ToString(), false);
                animator.SetBool(ETransitionHandParameter.ERock.ToString(), false);

            }
            else
            {
                animator.SetBool(ETransitionHandParameter.EScissor.ToString(), false);
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

