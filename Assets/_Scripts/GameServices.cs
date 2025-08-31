using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameServices : MonoBehaviour
{
    public static GameServices Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}