using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class EKeyboardInput : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                EVirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                EVirtualInputManager.Instance.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                EVirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                EVirtualInputManager.Instance.MoveLeft = false;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                EVirtualInputManager.Instance.Jump = true;
            }
            else
            {
                EVirtualInputManager.Instance.Jump = false;
            }

            if (Input.GetKey(KeyCode.I))
            {
                EVirtualInputManager.Instance.Rock = true;
            }
            else
            {
                EVirtualInputManager.Instance.Rock = false;
            }

            if (Input.GetKey(KeyCode.O))
            {
                EVirtualInputManager.Instance.Scissors = true;
            }
            else
            {
                EVirtualInputManager.Instance.Scissors = false;
            }

            if (Input.GetKey(KeyCode.P))
            {
                EVirtualInputManager.Instance.Paper = true;
            }
            else
            {
                EVirtualInputManager.Instance.Paper = false;
            }
        }
    }
}