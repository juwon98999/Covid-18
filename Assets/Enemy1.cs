using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    public Slider Hpbar;
    public float damage =1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Hpbar.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HandleHp()
    {
        Hpbar.value -= damage;
    }

}
