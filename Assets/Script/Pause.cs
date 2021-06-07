using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    private bool isPaused;
    private bool SoundSet;


    public GameObject pause;
    public GameObject SoundSetting;
    public GameObject Xbtn;
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Map1");
    }
    public void GoEnding()
    {
        SceneManager.LoadScene("Ending");
    }
    // Start is called before the first frame update
    public void SoundBtnClick()
    {
        SoundSetting.SetActive(true);
    }
    public void XbtnClick()
    {
        SoundSetting.SetActive(false);
    }

    void Start()
    {
        //pause.SetActive(false);
        SoundSetting.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (pause.activeSelf)
            {
                pause.SetActive(false);
                Time.timeScale = 1;
                
            }
            else
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }     
        }
    }
   
}

