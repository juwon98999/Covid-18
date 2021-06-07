using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)//상태에 진입할때
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)//상태가 진행중일때
    {
        if (enemy.enemyHp <= 0)
        {
            animator.SetTrigger("Die");
        }
        if (enemy.atkDelay <= 0)//공격 쿨타임이 0 돼면
        animator.SetTrigger("Attack");

        if (Vector2.Distance(enemy.player.position, enemyTransform.position) > 4f)
            animator.SetBool("isFollow",true);
        enemy.DirectionEnemy(enemy.player.position.x, enemyTransform.position.x);//적이 보는 방향이 플레이어 쪽이 되도록만듬
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state//상태를 빠져나갔을때
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.enemyHp <= 0)
        {
            animator.SetTrigger("Die");
        }
    }
}
