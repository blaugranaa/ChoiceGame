using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnChooseScreeenOpen = new UnityEvent();
    public static UnityEvent OnChange = new UnityEvent();
    public static UnityEvent OnCharacterDie = new UnityEvent();
    public static UnityEvent OnCharacterSurvive = new UnityEvent();
    public static UnityEvent OnOtherCharacterSurvive = new UnityEvent();

}
