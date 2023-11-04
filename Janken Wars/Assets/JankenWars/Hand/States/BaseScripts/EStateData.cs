using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public abstract class EStateData : ScriptableObject
    {
        public abstract void OnEnter(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void UpdateAbility(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExit(ECharacterState characterState, Animator animator, AnimatorStateInfo stateInfo);
    }
}