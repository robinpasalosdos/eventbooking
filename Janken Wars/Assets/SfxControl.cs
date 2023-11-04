using roundbeargames_tutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SfxControl : MonoBehaviour
{
    public GameObject sounds;
    private Sounds Sfx;
    public Toggle toggle;
    private void Update()
    {
        Sfx = sounds.GetComponent<Sounds>();
        toggle.onValueChanged.AddListener(delegate { SfxMusic(toggle); });
    }
    public void SfxMusic(Toggle ftoggle)
    {
        if (!ftoggle.isOn)
        {
            Sfx.enabled = false;
        }
        else
        {
            Sfx.enabled = true;
        }
    }

}
