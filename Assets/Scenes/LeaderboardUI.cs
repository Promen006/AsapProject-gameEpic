using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    public Transform leaderboardContainer; // Контейнер для строк таблицы лидеров
    private Font defaultFont;

    void Start()
    {
        defaultFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
        
        // Пример использования: добавление строки с именем и очками
        AddScoreEntry("Player1", 1000);
        AddScoreEntry("Player2", 500);
    }

    public void AddScoreEntry(string playerName, int score)
    {
        // Создаем корневой объект для строки
        GameObject row = new GameObject("ScoreEntry");
        row.AddComponent<HorizontalLayoutGroup>();
        row.transform.SetParent(leaderboardContainer);

        // Создаем текст для имени игрока
        GameObject nameTextObj = new GameObject("PlayerName");
        Text nameText = nameTextObj.AddComponent<Text>();
        nameText.text = playerName;
        nameText.font = defaultFont;
        nameText.alignment = TextAnchor.MiddleLeft;
        nameTextObj.transform.SetParent(row.transform);

        // Создаем текст для очков
        GameObject scoreTextObj = new GameObject("Score");
        Text scoreText = scoreTextObj.AddComponent<Text>();
        scoreText.text = score.ToString();
        scoreText.font = defaultFont;
        scoreText.alignment = TextAnchor.MiddleRight;
        scoreTextObj.transform.SetParent(row.transform);
    }
}