using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class RecordTable : MonoBehaviour
{
    public string filePath = "records.txt"; // ���� � ����� � ��������

    private List<RecordEntry> records = new List<RecordEntry>(); // ������ �������

    // ��������� ��� �������� ������ � ������� ��������
    [System.Serializable]
    public struct RecordEntry
    {
        public string playerName; // ��� ������
        public int score; // ����
    }

    void Start()
    {
        // ��������� ������ �� ����� ��� ������� ����
        LoadRecords();
    }

    // ������� ��� ���������� ����� ������ � ������� ��������
    public void AddRecord(string playerName, int score)
    {
        // ������� ����� ������
        RecordEntry newRecord = new RecordEntry { playerName = playerName, score = score };

        // ��������� ������ � ������
        records.Add(newRecord);

        // ��������� ������ �� �������� �����
        records.Sort((a, b) => b.score - a.score);

        // ��������� ������ � ����
        SaveRecords();
    }

    // ������� ��� �������� ������� �� �����
    private void LoadRecords()
    {
        // ���������, ���������� �� ����
        if (File.Exists(filePath))
        {
            // ������ ���������� �����
            string[] lines = File.ReadAllLines(filePath);

            // ������ ������ �� �����
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

    // ������� ��� ���������� ������� � ����
    private void SaveRecords()
    {
        // ����������� ������ � ��������� ������
        string[] lines = new string[records.Count];
        for (int i = 0; i < records.Count; i++)
        {
            lines[i] = records[i].playerName + "," + records[i].score;
        }

        // ���������� ��������� ������ � ����
        File.WriteAllLines(filePath, lines);
    }

    // ������� ��� ��������� ������ ��������
    public List<RecordEntry> GetRecords()
    {
        return records;
    }
}