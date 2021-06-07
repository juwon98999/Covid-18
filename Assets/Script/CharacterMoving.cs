using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMoving : MonoBehaviour
{ //변수들
    public bool move = true;
    Animator ani;
    SpriteRenderer spriterenderer;
    AudioSource Audio;
    AudioSource AudioWalk;

    private float curTime;
    public float coolTime = 0.5f;

    public Transform pos;
    public Vector2 boxSize;

    public AudioClip hitSound;
    public AudioClip hitSound2;
    public AudioClip hurtSound;
    public AudioClip HealSound;
    public AudioClip ScoreUpSound;
    public AudioClip GameOverSound;
    public AudioClip GameClearSound;

    public Text scoreText;
    public float score;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject[] Particle;
    public GameObject GameOverPannel;
    public GameObject GameClearPannel;

    public int PlayerHp;//= Mathf.Clamp(5, 0, 5);

    Enemy1 enemy1;

    // Start is called before the first frame update

    void Start()
    {
        //애니메이터 및 렌더러 가져오기
        ani = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        Audio = GetComponent<AudioSource>();
        AudioWalk = GetComponent<AudioSource>();
        PlayerHp = 5;
        Particle[0].SetActive(false);
        enemy1 = GetComponent<Enemy1>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {//이동 및 애니메이션
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        ani.SetFloat("inputX", inputX);
        ani.SetFloat("inputY", inputY);

        if (PlayerHp <= 0)
        {
            GameOver();
        }

        if(score >= 30)
        {
            GameClear();
        }


        if (inputX != 0 || inputY != 0)
            ani.SetBool("Walking", true);

        else ani.SetBool("Walking", false);

        if (move == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, inputY, 0) * Time.deltaTime * 5.0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, inputY, 0) * Time.deltaTime * 5.0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(5, 0, 0) * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(5, inputY, 0) * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            //transform.Translate(new Vector3(inputX, inputY,0) * Time.deltaTime * 5.0f);

            // if (Input.GetButton("Horizontal"))
            // {
            //     spriterenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            //transform.eulerAngles = new Vector3(0, 180, 0);
            // }

            // else spriterenderer.flipX = false;
        }





        //공격키
        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);//공격시 공격범위 콜라이더 설정
                foreach (Collider2D collider in collider2Ds)//foreach와 if문 사용해 Enemy태그 콜라이더만 추출
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().TakeDamage(1);
                        Audio.clip = hitSound;
                        Audio.Play();
                    }
                }

                ani.SetTrigger("Atk");
                curTime = coolTime;
                move = false;
            }
            if (Input.GetKey(KeyCode.X))
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().TakeDamage(1);
                        Audio.clip = hitSound2;
                        Audio.Play();
                    }
                }

                ani.SetTrigger("Atk2");
                curTime = coolTime;
                move = false;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
    //플레이어가 데미지 입을때
    public void TakeDamagePlayer(int damage)
    {
        PlayerHp = PlayerHp - damage;
        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "Time", 0.5f));
        Audio.clip = hurtSound;
        Audio.Play();
    }
    //공격 범위 표시
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    public void dieEnemy()
    {
        score +=1.0f;
        scoreText.text = score + " 명";
    }
    //체력 0됐을때 게임오버 
    public void GameOver()
    {
        GameOverPannel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameClear()
    {
        GameClearPannel.SetActive(true);
        Time.timeScale = 0;
    }
    //
    //아이템 먹을시 체력증가
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item1"))
        {
            Particle[0].SetActive(true);
            GameObject HealParticle = Instantiate(Particle[0],pos.parent);
            Destroy(HealParticle, 2f);
            Audio.clip = HealSound;
            Audio.Play();
        }
        if (collision.CompareTag("item2"))
        {
            Particle[0].SetActive(true);
            GameObject HealParticle = Instantiate(Particle[0], pos.parent);
            Destroy(HealParticle, 2f);
            Audio.clip = HealSound;
            Audio.Play();
        }
        if (collision.CompareTag("item3"))
        {
            Particle[0].SetActive(true);
            GameObject HealParticle = Instantiate(Particle[0], pos.parent);//, transform.position, Quaternion.identity);
            Destroy(HealParticle, 2f);
            Audio.clip = HealSound;
            Audio.Play();
        }
    }
}
 