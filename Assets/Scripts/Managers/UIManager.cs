using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject stayButton, changeButton, choiceText;

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
        Debug.Log("changed");

        SetInactiveButtons();
        Time.timeScale = 1;
    }
}
