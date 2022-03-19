using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instanse;

    public Color TeamColor;

    private void Awake()
    {
        if (Instanse != null)
        {
            Destroy(gameObject);
            return;
        }

        Instanse = this;
        DontDestroyOnLoad(gameObject);
    }
}
