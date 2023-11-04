using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class Sounds : MonoBehaviour
    {
        public AudioSource Walk;
        public AudioSource Grounded;
        public AudioSource EGrounded;
        public AudioSource EJump;
        public AudioSource Jump;
        public AudioSource Falling;
        public AudioSource EFalling;
        public AudioSource Fight;
        public AudioSource Close;
        public AudioSource EClose;
        public AudioSource Snap;
        public bool grounded;
        public bool ground;
        public bool eground;
        public bool jump;
        public bool falling;
        public bool efalling;
        public bool ejump;
        public bool close;
        public bool eclose;
        public bool fight;
        public bool snap;
        public bool esnap;

        private void Update()
        {
            GameObject player = GameObject.Find("SuitedMan");
            CharacterControl control = player.GetComponent<CharacterControl>();
            GameObject eplayer = GameObject.Find("Enemy");
            ECharacterControl econtrol = eplayer.GetComponent<ECharacterControl>();

            if (Grounded.isPlaying)
            {
                ground = true;
            }
            if (control.grounded && !ground)
            {
                Grounded.Play();
            }
            if (control.transform.position.y > 1.4f)
            {
                ground = false;
            }

            if (((control.MoveRight || control.MoveLeft) && control.grounded && !Walk.isPlaying && !control.Jump)||((econtrol.MoveRight || econtrol.MoveLeft) && econtrol.grounded && !Walk.isPlaying && !econtrol.Jump))
            {
                Walk.Play();
            }
            if (!control.MoveRight && !control.MoveLeft && !econtrol.MoveRight && !econtrol.MoveLeft)
            {
                Walk.Stop();
            }

            if (Jump.isPlaying)
            {
                jump = true;
            }
            if (control.Jump && !jump)
            {
                Jump.Play();
            }
            if (control.grounded)
            {
                Jump.Stop();
                jump = false;
            }

            if (Falling.isPlaying)
            {
                falling = true;
            }
            if (control.hole && !falling)
            {
                Falling.Play();
            }
            if (control.grounded)
            {
                Falling.Stop();
                falling = false;
            }

            if (Close.isPlaying)
            {
                close = true;
            }
            if (!close && control.Meet)
            {
                Close.Play();
            }
            if (!control.Meet)
            {
                close = false;
            }

            if (Fight.isPlaying)
            {
                fight = true;
            }
            if (!fight && (control.draw || control.win || control.lose))
            {
                Fight.Play();
            }
            if ((control.duration > 0f && control.draw) || control.Meet)
            {
                fight = false;
            }
            if (control.duration > 1.8f)
            {
                Fight.Stop();
            }

            if (Snap.isPlaying)
            {
                snap = true;
            }
            if(!snap && control.duration > 2f)
            {
                Snap.Play();
            }
            if (control.Meet)
            {
                snap = false;
            }


            if (EGrounded.isPlaying)
            {
                eground = true;
            }
            if (econtrol.grounded && !eground)
            {
                EGrounded.Play();
            }
            if (econtrol.transform.position.y > 1.4f)
            {
                eground = false;
            }

            if (EJump.isPlaying)
            {
                ejump = true;
            }
            if (econtrol.Jump && !ejump)
            {
                EJump.Play();
            }
            if (econtrol.grounded)
            {
                EJump.Stop();
                ejump = false;
            }

            if (EFalling.isPlaying)
            {
                efalling = true;
            }
            if (econtrol.hole && !efalling)
            {
                EFalling.Play();
            }
            if (econtrol.grounded)
            {
                EFalling.Stop();
                efalling = false;
            }

            if (EClose.isPlaying)
            {
                eclose = true;
            }
            if (!eclose && econtrol.Meet)
            {
                EClose.Play();
            }
            if (!econtrol.Meet)
            {
                eclose = false;
            }

        }
    }
}
