using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ü�� 2ĭ���� ������
        if (collision.CompareTag("Player"))
        {
            CharacterMoving characterMoving = GameObject.Find("���ΰ�").GetComponent<CharacterMoving>();
            if (characterMoving.PlayerHp >= 5)
            {
                Destroy(gameObject);
            }
            else if (characterMoving.PlayerHp == 4)
            {
                characterMoving.PlayerHp += 1;
                Destroy(gameObject);
            }
            else if (characterMoving.PlayerHp == 3)
            {
                characterMoving.PlayerHp += 2;
                Destroy(gameObject);
            }
            else if (characterMoving.PlayerHp <= 2)
            {
                characterMoving.PlayerHp += 2;
                Destroy(gameObject);
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
