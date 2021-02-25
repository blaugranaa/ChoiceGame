using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    //Animator animator;
    //Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Animator>())
        {
            SetTrigger("OnDie", collision.gameObject);
        }
    }

    void SetTrigger(string state, GameObject @object)
    {
        @object.gameObject.GetComponent<Animator>().SetTrigger(state);
    }
}
