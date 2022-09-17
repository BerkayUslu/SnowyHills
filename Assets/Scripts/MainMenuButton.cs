using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MainMenuButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager._instance.DestroyObject();
        SceneManager.LoadScene("StartScene");
        GameManager._instance.PauseGame(false);
    }
}
