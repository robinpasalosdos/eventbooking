using roundbeargames_tutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool pause;
    public GameObject PMenu;
    public GameObject sounds;
    public ManualInput control;
    public EManualInput econtrol;
    public BGSound Bgm;


    void Update()
    {
        GameObject player = GameObject.Find("SuitedMan");
        control = player.GetComponent<ManualInput>();
        GameObject eplayer = GameObject.Find("Enemy");
        econtrol = eplayer.GetComponent<EManualInput>();
        Bgm = sounds.GetComponent<BGSound>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Resume();
                
            }
            else
            {
                PMenu.SetActive(true);
                Time.timeScale = 0f;
                pause = true;
                control.enabled = false;
                econtrol.enabled = false;
            }
        }

        
    }
    public void Resume()
    {
        PMenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
        control.enabled = true;
        econtrol.enabled = true;

    }
    public void Menu()
    {

    }
}
