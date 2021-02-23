using UnityEngine;

public class CharacterAnimationController2 : MonoBehaviour
{
    Animator animator;
    Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    private void OnEnable()
    {
        EventManager.OnOtherCharacterSurvive.AddListener(() => SetTrigger("OnSurvive"));
    }

    private void OnDisable()
    {
        EventManager.OnOtherCharacterSurvive.RemoveListener(() => SetTrigger("OnSurvive"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RouteSwitch>())
        {
            SetTrigger("OnDie");
            //Destroy(gameObject);
            EventManager.OnCharacterDie.Invoke();
        }
    }

    void SetTrigger(string state)
    {
        Animator.SetTrigger(state);
    }


}