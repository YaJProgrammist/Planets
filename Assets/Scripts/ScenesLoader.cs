using UnityEngine.SceneManagement;

public static class ScenesLoader
{
    private static string mainMenuSceneName = "MainMenu";

    private static string gameplaySceneName = "GameplayScene";

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public static void LoadGameplay()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }
}
