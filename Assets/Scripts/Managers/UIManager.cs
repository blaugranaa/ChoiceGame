using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject stayButton, changeButton, choiceText, tooL8Text;

    bool isButtonPressed = false;
    public List<Character> StayCharacters = new List<Character>();
    public List<Character> ChangeCharacters = new List<Character>();

    public void ChooseScreenOpen()
    {  
        EventManager.OnChooseScreeenOpen.Invoke();
        SetActiveButtons(); 
    }

    public void CheckChoose()
    {
        if (!isButtonPressed)
        {
            StartCoroutine(TooLateCo(0.1f));
        }
    }

    IEnumerator TooLateCo(float time)
    {
        yield return new WaitForSeconds(time);
        //TooLateToChoose();
        Stay();
        tooL8Text.SetActive(true);
    }
    
    void SetActiveButtons()
    {
        stayButton.SetActive(true);
        changeButton.SetActive(true);
        choiceText.SetActive(true);
    }

    public void Change()
    {
        isButtonPressed = true;
        Debug.Log("changed");
        EventManager.OnCharacterSurvive.Invoke(ChangeCharacters);
        Time.timeScale = 1;
        EventManager.OnChange.Invoke();
        SetInactiveButtons();
    }

    private void SetInactiveButtons()
    {
        stayButton.SetActive(false);
        changeButton.SetActive(false);
        choiceText.SetActive(false);
    }

    public void Stay()
    {
        isButtonPressed = true;
        EventManager.OnCharacterSurvive.Invoke(StayCharacters);
        Debug.Log("stayed");
        SetInactiveButtons();
        Time.timeScale = 1;
    }

    public void TooLateToChoose()
    {
        SetInactiveButtons();
        Time.timeScale = 1;
    }
}
