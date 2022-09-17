using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountUI : MonoBehaviour
{
    private void Start()
    {
        if (Account._instance.GetPlayerName().Length > 1)
        {
            gameObject.SetActive(false);
        }
    }
}
