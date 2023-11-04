using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class EVirtualInputManager : ESingleton<EVirtualInputManager>
    {
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Rock;
        public bool Scissors;
        public bool Paper;
    }
}