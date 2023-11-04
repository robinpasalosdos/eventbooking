using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/EAbilityData/EJump")]
    public class EJump : EStateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;
        public AnimationCurve Pull;

        public override void OnEnter(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * JumpForce);
            animator.SetBool(ETransitionParameter.EGrounded.ToString(), false);
        }

        public override void UpdateAbility(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ECharacterControl control = characterState.GetCharacterControl(animator);

            control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
            control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnExit(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}