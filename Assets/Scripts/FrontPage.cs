using UnityEngine;

public class FrontPage : MonoBehaviour, IStartPage
{
    public void DestroyIt()
    {
        Destroy(gameObject);
    }
}

interface IStartPage
{
    void DestroyIt();
}
