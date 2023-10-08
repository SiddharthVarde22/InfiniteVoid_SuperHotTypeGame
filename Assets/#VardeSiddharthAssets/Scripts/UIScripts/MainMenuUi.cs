using UnityEngine.UI;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{
    [SerializeField]
    Button playButton, quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    public void OnPlayPressed()
    {
        ServiceLocator.Instance.GetService<LevelLoaderService>(TypesOfService.LevelLoader).LoadNextLevel();
    }

    public void OnQuitPressed()
    {
        ServiceLocator.Instance.GetService<LevelLoaderService>(TypesOfService.LevelLoader).QuitTheGame();
    }
}
