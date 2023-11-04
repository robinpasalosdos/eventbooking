using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;
        public float EnemyDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            GameObject player = GameObject.Find("Enemy");
            ECharacterControl econtrol = player.GetComponent<ECharacterControl>();

            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveRight && control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }

                if (control.Meet || control.hole)
                {
                    control.MoveRight = false;
                    control.Jump = false;
                }

            }

            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
                if (control.Meet || control.hole)
                {
                    control.MoveLeft = false;
                    control.Jump = false;

                }
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFront(CharacterControl control)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 2.5f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, EnemyDistance) && hit.collider.gameObject.name == "Enemy")
                {
                    control.Meet = true;
                }
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    return true;
                }
            }

            return false;
        }

    }
}