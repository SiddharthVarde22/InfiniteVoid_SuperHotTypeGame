using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoaderService : MonoBehaviour, IGameService
{
    public void RegisterService(TypesOfService typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegesterService<LevelLoaderService>(typesOfService, (LevelLoaderService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfService.LevelLoader, this);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if((index + 1) < SceneManager.sceneCountInBuildSettings)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        SceneManager.LoadScene(index);
    }

    public void ReloadTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
