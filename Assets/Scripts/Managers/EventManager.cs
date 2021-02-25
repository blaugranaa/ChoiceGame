using UnityEngine.Events;
using System.Collections.Generic;
public static class EventManager 
{
    public static UnityEvent OnChooseScreeenOpen = new UnityEvent();
    public static UnityEvent OnChange = new UnityEvent();
    public static UnityEvent OnCharacterDie = new UnityEvent();
    public static CharacterSurviveEvent OnCharacterSurvive = new CharacterSurviveEvent();
}

public class CharacterSurviveEvent : UnityEvent<List<Character>> { }
