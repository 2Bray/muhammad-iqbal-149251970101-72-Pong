using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject optPanel;
    [SerializeField] private Slider ballSlider;
    [SerializeField] private Image ballFill;
    [SerializeField] private Text ballValue;
    [SerializeField] private Slider paddleSlider;
    [SerializeField] private Image paddleFill;
    [SerializeField] private Text paddleValue;
    [SerializeField] private Color[] dificultColor;

    private void Start()
    {
        //Setup untuk option sesuai dengan terakhir kali di setting.
        //Jika belum di setting, Nilai default diberikan 4

        int ballSpeed = OptionStaticScript.Instance.GetBallSpeed();
        ballSlider.value = ballSpeed;
        ballValue.text = ballSpeed.ToString();
        ballFill.color = dificultColor[ballSpeed - 4];

        int paddleSpeed = OptionStaticScript.Instance.GetPaddleSpeed();
        paddleSlider.value = paddleSpeed;
        paddleValue.text = paddleSpeed.ToString();
        paddleFill.color = dificultColor[paddleSpeed - 4];
    }

    public void PlayGame()
    {
        Debug.Log("Created By Muhammad Iqbal - 149251970101-72");
        SceneManager.LoadScene("MainGame");
    }

    public void OptionPanel()
    {
        //Akan dieksekusi untuk membuka & menutup panel option
        optPanel.SetActive(!optPanel.activeInHierarchy);
    }

    public void OpenCredit()
    {
        //Pergi ke scene credit
        SceneManager.LoadScene("Credit");
    }

    public void BallSpeed(float value)
    {
        //Untuk Mengatur Kecepatan Bola. Berada pada option
        //Fungsi ini dieksekusi slider

        //value float dapat diyakini adalah nilai int
        //karena setting whole numbers pada slider di centang
        int speed = (int)value;
        OptionStaticScript.Instance.SetBallSpeed(speed);

        ballValue.text = speed.ToString();
        ballFill.color = dificultColor[speed - 4];
    }

    public void PaddleSpeed(float value)
    {
        //Untuk Mengatur Kecepatan Paddle. Berada pada option
        //Fungsi ini dieksekusi slider

        //value float dapat diyakini adalah nilai int
        //karena setting whole numbers pada slider di centang
        int speed = (int)value;
        OptionStaticScript.Instance.SetPaddleSpeed(speed);

        paddleValue.text = speed.ToString();
        paddleFill.color = dificultColor[speed - 4];
    }
}
