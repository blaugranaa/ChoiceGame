using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject stayButton, changeButton, choiceText;

    public List<Character> StayCharacters = new List<Character>();
    public List<Character> ChangeCharacters = new List<Character>();

    public void ChooseScreenOpen()
    {  
        EventManager.OnChooseScreeenOpen.Invoke();
        SetActiveButtons();
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
        Time.timeScale = 1;
        EventManager.OnChange.Invoke();
        SetInactiveButtons();
        EventManager.OnOtherCharacterSurvive.Invoke();
    }

    private void SetInactiveButtons()
    {
        stayButton.SetActive(false);
        changeButton.SetActive(false);
        choiceText.SetActive(false);
    }

    public void Stay()
    {
        EventManager.OnCharacterSurvive.Invoke(StayCharacters);
        Debug.Log("stayed");
        SetInactiveButtons();
        Time.timeScale = 1;
    }
}
