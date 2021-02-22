using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    Animator animator;
    Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RouteSwitch>())
        {
            SetTrigger("OnDie");
        }
    }

    void SetTrigger(string state)
    {
        Animator.SetTrigger(state);
    }
}
