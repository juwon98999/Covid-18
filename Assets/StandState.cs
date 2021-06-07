using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : StateMachineBehaviour
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
        if (Vector2.Distance(enemyTransform.position, enemy.player.position) <= 8)//적과 플레이어와의 거리가 6보다 작거나 같을시 isFollow 스타뚜
            animator.SetBool("isFollow",true);
        if (enemy.enemyHp <= 0)
        {
            animator.SetTrigger("Die");
        }
    }


     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state//상태를 빠져나갔을때
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
