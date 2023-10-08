using UnityEngine.UI;
using UnityEngine;

public class GameWinMenu : MonoBehaviour
{
    [SerializeField]
    Button mainMenuButton, quitButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    public void OnMainMenuButtonPressed()
    {
        ServiceLocator.Instance.GetService<LevelLoaderService>(TypesOfService.LevelLoader).LoadLevel(0);
    }

    public void OnQuitButtonPressed()
    {
        ServiceLocator.Instance.GetService<LevelLoaderService>(TypesOfService.LevelLoader).QuitTheGame();
    }
}
