using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform player;
    public float speed;
    public Vector2 home;
    public float atkCooltime = 1;
    public float atkDelay;

    public Transform pos;
    public Vector2 boxSize;
    public int enemyHp;
    CharacterMoving characterMoving;
    Enemy1 enemy1;
    Enemy2 enemy2;
    Enemy3 enemy3;

    AudioSource AudioEnemy;
    public AudioClip ScoreUpSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        home = transform.position;
        //CharacterMoving characterMoving = GameObject.Find("주인공").GetComponent<CharacterMoving>();
        //characterMoving.PlayerHp = 5;
        characterMoving = GetComponent<CharacterMoving>();
        AudioEnemy = GetComponent<AudioSource>();
        enemy1 = GetComponent<Enemy1>();
        enemy2 = GetComponent<Enemy2>();
        enemy3 = GetComponent<Enemy3>();
    }

    public void DirectionEnemy(float target,float baseobj)
    {
        if (target < baseobj)
            animator.SetFloat("Direction", -1);
        else
            animator.SetFloat("Direction", 1);
    }
    // Update is called once per frame
    void Update()
    {
       if (atkDelay >= 0)
           atkDelay -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    public void AttackPlayer()
    {
        CharacterMoving characterMoving = GameObject.Find("주인공").GetComponent<CharacterMoving>();
        if (characterMoving.PlayerHp >= 0)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Player")
                {
                    collider.GetComponent<CharacterMoving>().TakeDamagePlayer(1);
                }
            }
        }
    }

    //플레이어가 공격시 체력 깎고 사망
    
    public void TakeDamage(int damage)
    {
        enemyHp = enemyHp - damage;
        if(enemyHp <= 0)
        {
            GameObject.Find("주인공").GetComponent<CharacterMoving>().dieEnemy();
            AudioEnemy.clip = ScoreUpSound;
            AudioEnemy.Play();
            Destroy(gameObject,0.5f);
        }
    }
}
