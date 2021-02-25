using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    Character character;
    Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

    Animator animator;

    Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    private void OnEnable()
    {
        EventManager.OnCharacterSurvive.AddListener(SurviveAnimation);
    }

    private void OnDisable()
    {
        EventManager.OnCharacterSurvive.AddListener(SurviveAnimation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RouteSwitch>())
        {
            DieAnimation();
        }
    }
    void SurviveAnimation(List<Character> characters)
    {
        bool isOnList = false;
        for (int i = 0; i < characters.Count; i++)
        {
            if(ReferenceEquals(characters[i], Character))
            {
                isOnList = true;
            }
        }

        if (!isOnList)
            Animator.SetTrigger("OnSurvive");
    }
    void DieAnimation()
    {
        Animator.SetTrigger("OnDie");
    }
}
