using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _mainMenuButton;
    private Button _button;

    private bool menuIsOpen = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OpenOrHideMenu);
    }

   private void OpenOrHideMenu()
    {
        menuIsOpen = !menuIsOpen;
        _restartButton.SetActive(menuIsOpen);
        _mainMenuButton.SetActive(menuIsOpen);

        if (menuIsOpen)
        {
            GameManager._instance.PauseGame(true);
        }
        else
        {
            GameManager._instance.PauseGame(false);
        }
    }

}
