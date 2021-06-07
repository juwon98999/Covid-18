using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public int page = 1;
    public Image Endingimg;
    public Sprite Firstimg;
    public Sprite Secondimg;
    public Sprite Thirdimg;

    public GameObject NextBtn;
    public GameObject Prevbtn;
    public GameObject MainSceneBtn;


    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    public void OnclickNextBtn() 
    {
        if (page < 3)
        {
            page += 1;
        }
    }
    public void OnclickPrevBtn()
    {
        if(page == 3)
        {
            page --;
        }
        if(page == 2)
        {
            page -= 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(page == 1)
        {
            Endingimg.sprite = Firstimg;
            MainSceneBtn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(page == 1)
        {
            NextBtn.SetActive(true);
            Prevbtn.SetActive(false);
            MainSceneBtn.SetActive(false);
            Endingimg.sprite = Firstimg;
        }
        if(page == 2)
        {
            NextBtn.SetActive(true);
            Prevbtn.SetActive(true);
            MainSceneBtn.SetActive(false);
            Endingimg.sprite = Secondimg;
        }
        if(page == 3)
        {
            Prevbtn.SetActive(true);
            NextBtn.SetActive(false);
            MainSceneBtn.SetActive(true);
            Endingimg.sprite = Thirdimg;
        }
    }
}
