using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/EAbilityData/EForceTransition")]
    public class EForceTransition : EStateData
    {
        [Range(0.01f, 1f)]
        public float TransitionTiming;

        public override void OnEnter(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ECharacterControl control = characterState.GetCharacterControl(animator);
            if (stateInfo.normalizedTime >= TransitionTiming)
            {
                animator.SetBool(ETransitionParameter.EForceTransition.ToString(), true);
            }
        }

        public override void OnExit(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(ETransitionParameter.EForceTransition.ToString(), false);
        }
    }
}