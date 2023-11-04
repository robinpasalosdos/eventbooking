using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public enum ETransitionParameter
    {
        EMove,
        EJump,
        EForceTransition,
        EGrounded,
   
    }

    public class ECharacterControl : MonoBehaviour
    {
        public Animator animator;
        public Transform hand;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Rock;
        public bool Scissors;
        public bool Paper;
        public bool Meet;
        public bool Reveal;
        public bool hole;
        public bool victory;
        public bool grounded;
        public float vertical;
        public GameObject ColliderEdgePrefab;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();

        public bool win;
        public bool lose;
        public bool draw;
        public float duration;

        private EManualInput manualInput;

        public float GravityMultiplier;
        public float PullMultiplier;

        private Rigidbody rigid;
        public Rigidbody RIGID_BODY
        {
            get
            {
                if (rigid == null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }
        }

        private void Awake()
        {
            manualInput = this.gameObject.GetComponent<EManualInput>();

            BoxCollider box = GetComponent<BoxCollider>();
            

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z - box.bounds.extents.z;
            float back = box.bounds.center.z + box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom, back));
            GameObject topFront = CreateEdgeSphere(new Vector3(0f, top, front));

            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;
            topFront.transform.parent = this.transform;

            BottomSpheres.Add(bottomFront);
            BottomSpheres.Add(bottomBack);

            FrontSpheres.Add(bottomFront);
            FrontSpheres.Add(topFront);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            CreateMiddleSpheres(bottomFront, -this.transform.forward, horSec, 4, BottomSpheres);

            float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, FrontSpheres);
        }

        private void FixedUpdate()
        {
            if (RIGID_BODY.velocity.y < 0f)
            {
                RIGID_BODY.velocity += (-Vector3.up * GravityMultiplier);
            }

            if (RIGID_BODY.velocity.y > 0f && !Jump)
            {
                RIGID_BODY.velocity += (-Vector3.up * PullMultiplier);
            }

            
        }

        private void Update()
        {
            GameObject eplayer = GameObject.Find("SuitedMan");
            CharacterControl econtrol = eplayer.GetComponent<CharacterControl>();
            if (transform.position.y < 1f)
            {
                hole = true;
            }
            if (transform.position.y < -6f)
            {
                transform.position = new Vector3(0f, 1.5f, transform.position.z + 1.25f);
                hole = false;
            }
            if (Meet)
            {
                hand.transform.position = new Vector3(0f, -35.5f, transform.position.z);
                animator.transform.position = new Vector3(0f, 10f, transform.position.z);
            }

            if (draw)
            {
                duration += Time.deltaTime;
                if (duration > 2f)
                {
                    Reveal = false;
                    Rock = false;
                    Paper = false;
                    Scissors = false;
                    duration = 0;
                    draw = false;
                }

            }

            if (duration > 2.5f && win)
            {
                win = false;
                duration = 0;
            }
            if (win)
            {
                duration += Time.deltaTime;
                if (duration > 2f)
                {
                    hand.transform.position = new Vector3(0f, 0f, transform.position.z);
                    animator.transform.position = new Vector3(0f, 1.325f, transform.position.z);
                    Meet = false;
                    Reveal = false;
                    Rock = false;
                    Paper = false;
                    Scissors = false;
                }
                if (hole)
                {
                    transform.position = new Vector3(0f, 1.325f, transform.position.z - 1f);
                    hole = false;
                }

            }
            if (lose)
            {
                duration += Time.deltaTime;
                if (duration > 2f)
                {
                    vertical += .02f;
                    hand.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                    animator.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    transform.position = new Vector3(0f, 1.325f + vertical, transform.position.z + 20f * Time.deltaTime);
                    Meet = false;
                    Reveal = false;
                    Rock = false;
                    Paper = false;
                    Scissors = false;
                    victory = false;
                }
                if (transform.position.z > 33.2f)
                {
                    lose = false;
                    duration = 0;
                    vertical = 0;
                }
            }

            if (transform.position.z <= -.2f)
            {
                victory = true;
            }

            if ((victory && !Meet) || (econtrol.victory && !econtrol.Meet))
            {
                manualInput.enabled = false;
                MoveRight = false;
                MoveLeft = false;
                Jump = false;
                Meet = false;
            }
        }

        public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
        {
            for (int i = 0; i < interations; i++)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i + 1));

                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                spheresList.Add(newObj);
            }
        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }

    }
}