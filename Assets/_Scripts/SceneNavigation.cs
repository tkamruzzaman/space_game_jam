using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public static SceneNavigation Instance;
    
    void Awake()
    {
        Instance = this;
    }

    public void LoadScene(Scenes sceneIndex)
    {
        SceneManager.LoadScene((int)sceneIndex);
    }
}


public enum Scenes
{
    MainMenu = 0,
    Game = 1,
    //GameOver = 2
}
