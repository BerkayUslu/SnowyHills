using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _startSceneUI;
    [SerializeField] private GameObject _u─▒ThatWillBeDisabled;

    public void ShowStartUI()
    {
        _startSceneUI.SetActive(true);
        _u─▒ThatWillBeDisabled.SetActive(false);
    }
}
