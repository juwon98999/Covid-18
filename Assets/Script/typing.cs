using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typing : MonoBehaviour
{
    public Text tx;
    private string m_text = "서기 2020년... 세상은 코로나 바이러스로 골머리를 앓고 있다. 나날이 늘어가는 확진자와 폐업하는 가게들, 정부의 방역 지침을 준수하지 않는 사람들까지... 그리고 여기, 폐업으로 인해 헬스장에 다니지 못하게 된 남자가있다. 그는 반드시 다시 헬스장을 다녀야만 한다. 거리에 마스크를 쓰지않은 사람들이 많으니 교육을 해야한다.";
    
    public GameObject StartBtn;
    public GameObject KeyGuide;
    public GameObject StartBtn2;
    public GameObject KeyGuide2;
    public GameObject Pannel;
    public GameObject Tx2;
    public GameObject EnemyHPimg;
    public GameObject EnemyHPimg2;
  

    Coroutine HardStopCoroutine;

    public void Textskip()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(HardStopCoroutine);
            
            KeyGuide2.SetActive(true);
            StartBtn2.SetActive(true);
            Tx2.SetActive(true);
            EnemyHPimg2.SetActive(true);
            //StartBtn.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HardStopCoroutine = StartCoroutine(Typing());
       
        KeyGuide2.SetActive(false);
        StartBtn2.SetActive(false);
        StartBtn.SetActive(false);
        Tx2.SetActive(false);
        KeyGuide.SetActive(false);
        EnemyHPimg.SetActive(false);
        EnemyHPimg2.SetActive(false);

    }
    IEnumerator Typing()
    {
        //yield return new WaitForSeconds(2f);  38.51,50,38,23,35
        
            for (int i = 0; i <= m_text.Length; i++)
            {
                if (i == 184)
                {
                    StartBtn.SetActive(true);
                    KeyGuide.SetActive(true);
                    EnemyHPimg.SetActive(true);
                }
                else
                {
                    StartBtn.SetActive(false);
                }
                tx.text = m_text.Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }
       
    }
    //tx.text = m_text.Substring(0,27);
           // tx.text = m_text.Substring(27,23);
          // tx.text = m_text.Substring(23,29);
          //  tx.text = m_text.Substring(29,38);
          //  tx.text = m_text.Substring(38,23);
         //   tx.text = m_text.Substring(23,35);
    // Update is called once per frame
    void Update()
    {
        Textskip();
    }
}
