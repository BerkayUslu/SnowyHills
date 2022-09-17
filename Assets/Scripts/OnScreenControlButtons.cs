using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenControlButtons : MonoBehaviour
{
   private void Start()
   {
      gameObject.SetActive(Options._instance.GetUIControllerState());
   }
}
