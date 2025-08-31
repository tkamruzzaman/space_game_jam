using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public static UIGamePlay Instance;

    [SerializeField] Button mainMenuButton;
    [SerializeField] Image healthBar;
    [SerializeField] Image junkCollectionBar;

    void Awake()
    {
        Instance = this;

        mainMenuButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayButtonClick();
            SceneNavigation.Instance.LoadScene(Scenes.MainMenu);
        });
    }
   

   public void UpdateHealthBar(float value = 0)
   {
       healthBar.fillAmount = value;
   }

   public void UpdateJunkCollectionBar(float value = 0)
   {
       junkCollectionBar.fillAmount = value;
   }
}
