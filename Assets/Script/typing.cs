using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typing : MonoBehaviour
{
    public Text tx;
    private string m_text = "���� 2020��... ������ �ڷγ� ���̷����� ��Ӹ��� �ΰ� �ִ�. ������ �þ�� Ȯ���ڿ� ����ϴ� ���Ե�, ������ �濪 ��ħ�� �ؼ����� �ʴ� ��������... �׸��� ����, ������� ���� �ｺ�忡 �ٴ��� ���ϰ� �� ���ڰ��ִ�. �״� �ݵ�� �ٽ� �ｺ���� �ٳ�߸� �Ѵ�. �Ÿ��� ����ũ�� �������� ������� ������ ������ �ؾ��Ѵ�.";
    
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
