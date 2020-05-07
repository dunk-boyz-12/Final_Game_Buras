using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class E_FollowBehavior : StateMachineBehaviour
{
    [SerializeField] private Transform Player; //to find player
    public Rigidbody2D e;
    private float followSpeed = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; //find player position
        e = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //follow player
        //switch back if player gets too far
        //animator.GetComponent<Enemy>().FacePlayer();
        Vector2 targPos = new Vector2(Player.position.x, e.position.y);
        Vector2 newPos = Vector2.MoveTowards(animator.transform.position, Player.position, followSpeed * Time.deltaTime);
        e.MovePosition(newPos);

        if((Player.transform.position.x - animator.transform.position.x) < 0)
        {
            animator.transform.eulerAngles = new Vector2(0, 180);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
