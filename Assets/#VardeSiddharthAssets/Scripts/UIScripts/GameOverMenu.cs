using UnityEngine.UI;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    Button retryButton, menuButton;

    private void Start()
    {
        retryButton.onClick.AddListener(OnRetryButtonPressed);
        menuButton.onClick.AddListener(OnMenuButtinPressed);
    }

    public void OnRetryButtonPressed()
    {
        ServiceLocator.Instance.GetService<LevelLoaderService>(TypesOfService.LevelLoader).LoadLevel(1);
    }

    public void OnMenuButtinPressed()
    {
        ServiceLocator.Instance.GetService<LevelLoaderService>(TypesOfService.LevelLoader).LoadLevel(0);
    }
}
