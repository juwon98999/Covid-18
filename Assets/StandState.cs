using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)//���¿� �����Ҷ�
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)//���°� �������϶�
    {
        if (Vector2.Distance(enemyTransform.position, enemy.player.position) <= 8)//���� �÷��̾���� �Ÿ��� 6���� �۰ų� ������ isFollow ��Ÿ��
            animator.SetBool("isFollow",true);
        if (enemy.enemyHp <= 0)
        {
            animator.SetTrigger("Die");
        }
    }


     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state//���¸� ������������
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
