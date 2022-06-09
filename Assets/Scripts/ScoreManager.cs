using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text winText;
    [SerializeField] private Text textScore;
    private int maxScore = 5;

    //score akan berisi 2 index untuk mewakili kedua player.
    //idx 0 untuk skor yang dicetak oleh pemain kiri
    //idx 1 untuk skor yang dicetak oleh pemain kanan
    private int[] score = { 0, 0 };

    //Parameter idx akan mengacu pada siapa yang mencteak goal.
    public void AddScore(int idx)
    {
        //Karena tidak ada three point. Maka setiap skor yang dicetak hanya akan bernilai 1
        score[idx]++;
        textScore.text = "0" + score[0] + " : 0" + score[1];

        if (score[idx] >= maxScore) GameOver(idx);
        else StartCoroutine(FindObjectOfType<BallController>().startVelocity());
    }

    public void GameOver(int winner)
    {
        string win = winner == 0 ? "Left" : "Right";
        winText.text = win + " WIN !!!";
        winPanel.SetActive(true);

        StartCoroutine(ToMainMenu());
    }

    private IEnumerator ToMainMenu()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        SceneManager.LoadScene("MainMenu");
    }
}
