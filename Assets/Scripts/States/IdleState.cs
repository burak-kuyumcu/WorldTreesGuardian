using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    float timer = 0;
    Transform player;

    public float agroDistance; // Public yap�larak Inspector'da ayarlanabilir

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        // Player'� bulmaya �al��, bulamazsan null olarak ayarla
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            player = null;
            Debug.LogWarning("Player bulunamad�!");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            animator.SetBool("isPatrolling", true);
        }

        // Player'�n varl���n� kontrol et
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, animator.transform.position);

            if (distance < agroDistance)
            {
                animator.SetBool("isChasing", true);
            }
        }
        else
        {
            Debug.LogWarning("Player null, hedef takip edilemiyor!");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ��k�� durumunda �zel bir i�lem yok
    }
}
