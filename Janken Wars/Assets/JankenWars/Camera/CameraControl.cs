using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class CameraControl : MonoBehaviour
    {
        private float center;
        private float playerPosition;
        private float xPosition;
        private float xPositionWin;
        private float zPositionWin;
        private float yPosition;
        private float xRotation;

        private void Update()
        {
            GameObject player = GameObject.Find("SuitedMan");
            CharacterControl control = player.GetComponent<CharacterControl>();
            GameObject eplayer = GameObject.Find("Enemy");
            ECharacterControl econtrol = eplayer.GetComponent<ECharacterControl>();

            playerPosition = player.transform.position.z;
            center = ((eplayer.transform.position.z - playerPosition) / 2f) + playerPosition;
            xPosition = eplayer.transform.position.z - playerPosition;
            xRotation = xPosition / 3f;
            yPosition = xRotation / 1.5f + 1.7f;
            transform.position = new Vector3(xPosition, yPosition, center);
            transform.rotation = Quaternion.Euler(xRotation, -90f, 0f);

            if (control.victory && !control.Meet)
            { 
                if (center - zPositionWin > control.transform.position.z)
                {
                    zPositionWin += .05f;
                }

                if (transform.position.x - xPositionWin > 4f)
                {
                    xPositionWin += .05f;
                }
                transform.position = new Vector3(transform.position.x - xPositionWin, yPosition - zPositionWin/3f, center - zPositionWin);
            }

            if (econtrol.victory && !econtrol.Meet)
            {
                if (center + zPositionWin < econtrol.transform.position.z)
                {
                    zPositionWin += .05f;
                }

                if (transform.position.x - xPositionWin > 4f)
                {
                    xPositionWin += .05f;
                }
                transform.position = new Vector3(transform.position.x - xPositionWin, yPosition - zPositionWin/3f, center + zPositionWin);
            }

        }
    }
}
