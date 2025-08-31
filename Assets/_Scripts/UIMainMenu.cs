#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button exitButton;

    void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClick();

            SceneNavigation.Instance.LoadScene(Scenes.Video);
        });

        exitButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClick();
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                EditorApplication.ExitPlaymode();
            }
#else
            Application.Quit();
#endif
        });
    }
}
