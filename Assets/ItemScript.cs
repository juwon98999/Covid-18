using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //체력 1칸증가 아이탬
        if (collision.CompareTag("Player"))
        {
            CharacterMoving characterMoving = GameObject.Find("주인공").GetComponent<CharacterMoving>();
            if (characterMoving.PlayerHp >= 5)
            {
                Destroy(gameObject);
            }
            else if (characterMoving.PlayerHp <= 4)
            {
                characterMoving.PlayerHp += 1;
                Destroy(gameObject);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
