using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Image HP;
    public Sprite ChangeHP5;
    public Sprite ChangeHP4;
    public Sprite ChangeHP3;
    public Sprite ChangeHP2;
    public Sprite ChangeHP1;
    public Sprite ChangeHP0;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        CharacterMoving characterMoving = GameObject.Find("¡÷¿Œ∞¯").GetComponent<CharacterMoving>();
        if (characterMoving.PlayerHp == 5)
        {
            HP.sprite = ChangeHP5;
        }
        if (characterMoving.PlayerHp == 4)
        {
            HP.sprite = ChangeHP4;
        }
        if (characterMoving.PlayerHp == 3)
        {
            HP.sprite = ChangeHP3;
        }
        if (characterMoving.PlayerHp == 2)
        {
            HP.sprite = ChangeHP2;
        }
        if (characterMoving.PlayerHp == 1)
        {
            HP.sprite = ChangeHP1;
        }
        if (characterMoving.PlayerHp <= 0)
        {
            HP.sprite = ChangeHP0;
        }
    }
}
