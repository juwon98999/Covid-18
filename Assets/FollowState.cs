using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : StateMachineBehaviour
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
        if (Vector2.Distance(enemyTransform.position, enemy.player.position) >= 6)//둘사이 거리가 6보다 작거나 같으면
        {
            animator.SetBool("isBack", true);
            animator.SetBool("isFollow", false);
        }else if (Vector2.Distance(enemy.player.position,enemyTransform.position)>2f)//적 공격 사거리
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, enemy.player.position,Time.deltaTime * enemy.speed);
        else
        {
            animator.SetBool("isBack", false);
            animator.SetBool("isFollow", false);
        }
        enemy.DirectionEnemy(enemy.player.position.x, enemyTransform.position.x);
        if (enemy.enemyHp <= 0)
        {
            animator.SetTrigger("Die");
        }
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
