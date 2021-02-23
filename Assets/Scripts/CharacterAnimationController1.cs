using UnityEngine;

public class CharacterAnimationController1 : MonoBehaviour
{
    Animator animator;
    Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    private void OnEnable()
    {
        EventManager.OnCharacterSurvive.AddListener(() => SetTrigger("OnSurvive"));
    }

    private void OnDisable()
    {
        EventManager.OnCharacterSurvive.RemoveListener(() => SetTrigger("OnSurvive"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RouteSwitch>())
        {
            SetTrigger("OnDie");
            //Destroy(gameObject);
            EventManager.OnOtherCharacterSurvive.Invoke();
        }
    }

    void SetTrigger(string state)
    {
        Animator.SetTrigger(state);
    }

}
