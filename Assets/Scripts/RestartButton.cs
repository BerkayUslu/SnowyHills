using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager._instance.DestroyObject();
        SceneManager.LoadScene("GameScene");
        GameManager._instance.PauseGame(false);
    }

}
