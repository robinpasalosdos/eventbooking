using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class ECharacterState : StateMachineBehaviour
    {
        public List<EStateData> EListAbilityData = new List<EStateData>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (EStateData d in EListAbilityData)
            {
                d.OnEnter(this, animator, stateInfo);
            }
        }

        public void UpdateAll(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (EStateData d in EListAbilityData)
            {
                d.UpdateAbility(characterState, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (EStateData d in EListAbilityData)
            {
                d.OnExit(this, animator, stateInfo);
            }
        }

        private ECharacterControl characterControl;
        public ECharacterControl GetCharacterControl(Animator animator)
        {
            if (characterControl == null)
            {
                characterControl = animator.GetComponentInParent<ECharacterControl>();
            }
            return characterControl;
        }
    }
}