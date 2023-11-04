using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/EAbilityData/EGroundDetector")]
    public class EGroundDetector : EStateData
    {
        [Range(0.01f, 1f)]
        public float CheckTime;
        public float Distance;

        public override void OnEnter(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ECharacterControl control = characterState.GetCharacterControl(animator);

            if (stateInfo.normalizedTime >= CheckTime)
            {
                if (IsGrounded(control))
                {
                    animator.SetBool(ETransitionParameter.EGrounded.ToString(), true);
                    control.grounded = true;
                }
                else
                {
                    animator.SetBool(ETransitionParameter.EGrounded.ToString(), false);
                    control.grounded = false;
                }

            }
        }

        public override void OnExit(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool IsGrounded(ECharacterControl control)
        {
            if (control.RIGID_BODY.velocity.y > -0.001f && control.RIGID_BODY.velocity.y <= 0f)
            {
                return true;
            }

            if (control.RIGID_BODY.velocity.y < 0f)
            {
                foreach (GameObject o in control.BottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}