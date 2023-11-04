using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/EAbilityData/EIdle")]
    public class EIdle : EStateData
    {
        public override void OnEnter(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(ETransitionParameter.EJump.ToString(), false);
        }

        public override void UpdateAbility(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ECharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump)
            {
                animator.SetBool(ETransitionParameter.EJump.ToString(), true);
            }

            if (control.MoveRight)
            {
                animator.SetBool(ETransitionParameter.EMove.ToString(), true);
            }

            if (control.MoveLeft)
            {
                animator.SetBool(ETransitionParameter.EMove.ToString(), true);
            }
        }

        public override void OnExit(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}