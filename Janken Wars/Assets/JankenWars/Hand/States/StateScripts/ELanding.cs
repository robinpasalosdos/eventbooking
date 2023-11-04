using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/EAbilityData/ELanding")]
    public class ELanding : EStateData
    {
        public override void OnEnter(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(ETransitionParameter.EJump.ToString(), false);
            animator.SetBool(ETransitionParameter.EMove.ToString(), false);
        }

        public override void UpdateAbility(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}