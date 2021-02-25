using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RouteSwitch>())
        {
            EventManager.OnCharacterDie.Invoke();
        }
    }
}
