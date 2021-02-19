using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject stayButton, changeButton;

   public void SetActiveButtons()
   {
       
        EventManager.OnChooseScreeenOpen.Invoke();
   }
}
