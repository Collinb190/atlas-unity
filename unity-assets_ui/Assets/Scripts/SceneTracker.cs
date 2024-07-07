public static class SceneTracker
{
    private static string previousScene;

    public static void SetPreviousScene(string sceneName)
    {
        previousScene = sceneName;
    }

    public static string GetPreviousScene()
    {
        return previousScene;
    }
}
