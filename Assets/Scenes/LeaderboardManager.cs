using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [System.Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int score;

        public ScoreEntry(string playerName, int score)
        {
            this.playerName = playerName;
            this.score = score;
        }
    }

    public List<ScoreEntry> leaderboard = new List<ScoreEntry>();
    public Transform leaderboardContainer;
    public GameObject scoreEntryPrefab;
    public int maxEntries = 10;

    void Start()
    {
        LoadLeaderboard();
        DisplayLeaderboard();
    }

    // Добавить новый рекорд в таблицу
    public void AddScore(string playerName, int score)
    {
        leaderboard.Add(new ScoreEntry(playerName, score));
        leaderboard.Sort((x, y) => y.score.CompareTo(x.score));  // Сортировка по убыванию
        if (leaderboard.Count > maxEntries)
            leaderboard.RemoveAt(leaderboard.Count - 1);  // Удаление лишних записей

        SaveLeaderboard();
        DisplayLeaderboard();
    }

    // Отобразить таблицу на UI
    private void DisplayLeaderboard()
    {
        // Очистка старых записей UI
        foreach (Transform child in leaderboardContainer)
            Destroy(child.gameObject);

        foreach (var entry in leaderboard)
        {
            GameObject scoreObj = Instantiate(scoreEntryPrefab, leaderboardContainer);
            Text[] texts = scoreObj.GetComponentsInChildren<Text>();
            texts[0].text = entry.playerName;
            texts[1].text = entry.score.ToString();
        }
    }

    // Сохранить таблицу в PlayerPrefs
    private void SaveLeaderboard()
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            PlayerPrefs.SetString($"PlayerName_{i}", leaderboard[i].playerName);
            PlayerPrefs.SetInt($"PlayerScore_{i}", leaderboard[i].score);
        }
        PlayerPrefs.SetInt("LeaderboardCount", leaderboard.Count);
        PlayerPrefs.Save();
    }

    // Загрузить таблицу из PlayerPrefs
    private void LoadLeaderboard()
    {
        leaderboard.Clear();
        int count = PlayerPrefs.GetInt("LeaderboardCount", 0);
        for (int i = 0; i < count; i++)
        {
            string name = PlayerPrefs.GetString($"PlayerName_{i}", "Unknown");
            int score = PlayerPrefs.GetInt($"PlayerScore_{i}", 0);
            leaderboard.Add(new ScoreEntry(name, score));
        }
    }
}
