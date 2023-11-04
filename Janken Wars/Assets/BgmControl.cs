using roundbeargames_tutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BgmControl : MonoBehaviour
{
    public GameObject sounds;
    private BGSound Bgm;
    public Toggle toggle;
    private void Update()
    {
        Bgm = sounds.GetComponent<BGSound>();
        toggle.onValueChanged.AddListener(delegate { BgMusic(toggle); });
    }
    public void BgMusic(Toggle ftoggle)
    {
        if (!ftoggle.isOn)
        {
            Bgm.BGMusic.Stop();
            Bgm.BGMusicClose.Stop();
            Bgm.Victory.Stop();
            Bgm.enabled = false;
        }
        else
        {
            Bgm.enabled = true;
        }
    }


}