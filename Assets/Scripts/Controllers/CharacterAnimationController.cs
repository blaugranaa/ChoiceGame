using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public List<GameObject> multiplevictim = new List<GameObject>();

    public GameObject lonelyVictim;

    private void OnEnable()
    {
        EventManager.OnChange.AddListener(LonelyVictimSurvive);
        EventManager.OnCharacterSurvive.AddListener(MultipleCharacterSurvive);
    }

    private void OnDisable()
    {
        EventManager.OnChange.RemoveListener(LonelyVictimSurvive);
        EventManager.OnCharacterSurvive.AddListener(MultipleCharacterSurvive);
    }

    void LonelyVictimSurvive()
    {
        lonelyVictim.GetComponent<Animator>().SetTrigger("OnSurvive");
    }

    void MultipleCharacterSurvive()
    {
        foreach (var character in multiplevictim)
        {
            character.GetComponent<Animator>().SetTrigger("OnSurvive");
        }
    }


}
