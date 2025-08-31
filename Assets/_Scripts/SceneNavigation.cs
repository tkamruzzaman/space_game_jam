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

    public int GetSceneIndex(Scenes scene)
    {
        return (int)scene;
    }
}


public enum Scenes
{
    MainMenu = 0,
    Video = 1,
    Game = 2,
    //GameOver = 3
}
