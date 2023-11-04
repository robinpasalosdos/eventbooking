using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.Jump = true;
            }
            else
            {
                VirtualInputManager.Instance.Jump = false;
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                VirtualInputManager.Instance.Rock = true;
            }
            else
            {
                VirtualInputManager.Instance.Rock = false;
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                VirtualInputManager.Instance.Scissors = true;
            }
            else
            {
                VirtualInputManager.Instance.Scissors = false;
            }

            if (Input.GetKey(KeyCode.Alpha3))
            {
                VirtualInputManager.Instance.Paper = true;
            }
            else
            {
                VirtualInputManager.Instance.Paper = false;
            }
        }
    }
}