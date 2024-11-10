using UnityEngine;
using TMPro; // Импорт библиотеки TextMeshPro

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Ссылка на текстовый компонент TMP_Text
    private float timeRemaining = 300f; // 5 минут в секундах

    void Update()
    {
        timeRemaining -= Time.deltaTime; // Уменьшаем время каждую секунду

        // Преобразование времени в минуты и секунды
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Отображение времени в текстовом поле

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Проверка, закончилось ли время
        if (timeRemaining <= 0)
        {
            // Выполните действие при окончании таймера
            Debug.Log("Время вышло!");
        }
    }
}