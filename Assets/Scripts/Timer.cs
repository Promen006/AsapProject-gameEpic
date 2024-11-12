using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // ������ ���������� TextMeshPro

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // ������ �� ��������� ��������� TMP_Text
    private float timeRemaining = 300f; // 5 ����� � ��������

    void Update()
    {
        timeRemaining -= Time.deltaTime; // ��������� ����� ������ �������

        // �������������� ������� � ������ � �������
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // ����������� ������� � ��������� ����

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // ��������, ����������� �� �����
        if (timeRemaining <= 0)
        {
            // ��������� �������� ��� ��������� �������
            SceneManager.LoadScene("Menu");
        }
    }
}