using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject stayButton, changeButton, choiceText, tooL8;

    public List<Character> StayCharacters = new List<Character>();
    public List<Character> ChangeCharacters = new List<Character>();

    public void ChooseScreenOpen()
    {
        SetActiveButtons();
        EventManager.OnChooseScreeenOpen.Invoke();
        StartCoroutine(ChooseScreenOffCo(1f));
    }

    IEnumerator ChooseScreenOffCo(float time)
    {
        yield return new WaitForSeconds(time);
        Stay();
        tooL8.SetActive(true);
        Time.timeScale = 1;
    }

    void SetActiveButtons()
    {
        stayButton.SetActive(true);
        changeButton.SetActive(true);
        choiceText.SetActive(true);
    }

    public void Change()
    {
        Debug.Log("changed");
        EventManager.OnCharacterSurvive.Invoke(ChangeCharacters);
        EventManager.OnChange.Invoke();
        SetInactiveButtons();
    }

    private void SetInactiveButtons()
    {
        stayButton.SetActive(false);
        changeButton.SetActive(false);
        choiceText.SetActive(false);
        Time.timeScale = 1;
    }

    public void Stay()
    {
        EventManager.OnCharacterSurvive.Invoke(StayCharacters);
        Debug.Log("stayed");
        SetInactiveButtons();
    }
}
