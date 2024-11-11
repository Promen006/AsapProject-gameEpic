using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class RecordTable : MonoBehaviour
{
    public string filePath = "records.txt"; // Путь к файлу с записями

    private List<RecordEntry> records = new List<RecordEntry>(); // Список записей

    // Структура для хранения записи в таблице рекордов
    [System.Serializable]
    public struct RecordEntry
    {
        public string playerName; // Имя игрока
        public int score; // Очки
    }

    void Start()
    {
        // Загружаем записи из файла при запуске игры
        LoadRecords();
    }

    // Функция для добавления новой записи в таблицу рекордов
    public void AddRecord(string playerName, int score)
    {
        // Создаем новую запись
        RecordEntry newRecord = new RecordEntry { playerName = playerName, score = score };

        // Добавляем запись в список
        records.Add(newRecord);

        // Сортируем список по убыванию очков
        records.Sort((a, b) => b.score - a.score);

        // Сохраняем записи в файл
        SaveRecords();
    }

    // Функция для загрузки записей из файла
    private void LoadRecords()
    {
        // Проверяем, существует ли файл
        if (File.Exists(filePath))
        {
            // Читаем содержимое файла
            string[] lines = File.ReadAllLines(filePath);

            // Парсим записи из файла
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    records.Add(new RecordEntry { playerName = parts[0], score = int.Parse(parts[1]) });
                }
            }
        }
    }

    // Функция для сохранения записей в файл
    private void SaveRecords()
    {
        // Преобразуем записи в строковый массив
        string[] lines = new string[records.Count];
        for (int i = 0; i < records.Count; i++)
        {
            lines[i] = records[i].playerName + "," + records[i].score;
        }

        // Записываем строковый массив в файл
        File.WriteAllLines(filePath, lines);
    }

    // Функция для получения списка рекордов
    public List<RecordEntry> GetRecords()
    {
        return records;
    }
}