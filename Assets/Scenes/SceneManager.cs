using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen; // Панель для отображения экрана загрузки
    public Slider loadingProgressBar; // Ползунок для отображения прогресса

    // Загрузка сцены по имени
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("Andrey");
        Score.AllScore = 0;
    }

    // Загрузка сцены по индексу
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Асинхронная загрузка сцены с прогрессом
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    // Перезагрузка текущей сцены
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Асинхронная корутина загрузки сцены с отображением прогресса
    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true); // Показать экран загрузки

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingProgressBar.value = progress; // Обновить ползунок прогресса
            yield return null;
        }

        loadingScreen.SetActive(false); // Скрыть экран загрузки по завершению
    }

    // Выход из приложения
    public void QuitGame()
    {
        Application.Quit();
    }
}