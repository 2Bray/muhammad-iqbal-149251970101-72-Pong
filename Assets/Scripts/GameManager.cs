using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] paddle;
    [SerializeField] GameObject ball;

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (ball.transform.position.x < paddle[0].transform.position.x - 1 ||
            ball.transform.position.x > paddle[1].transform.position.x + 1)
        {
            //Restart Ketika Bola Sudah Melewati Salah Satu Paddle

            ball.transform.position = new Vector3(0, 0, ball.transform.position.z);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(GameStart());
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(2f);
        ball.GetComponent<BallController>().startVelocity();
    }
}
