using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private int speed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private Color hitColor;
    private Rigidbody2D rig;

    private Vector3 normalSizePadle;
    private int incrementSpeed = 0;

    private float longPadle = 0;
    private float speedUpPadle = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = OptionStaticScript.Instance.GetPaddleSpeed();

        rig = GetComponent<Rigidbody2D>();
        normalSizePadle = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());

        //Timer Power Up
        if (longPadle > 0)
        {
            longPadle -= Time.deltaTime;
            if (longPadle <= 0) transform.localScale = normalSizePadle;
        }
        if (speedUpPadle > 0)
        {
            speedUpPadle -= Time.deltaTime; 
            if (speedUpPadle <= 0) incrementSpeed = 0;
        }
    }

    private Vector2 GetInput()
    {
        int direction = 0;

        if (Input.GetKey(upKey)) direction = 1;
        else if (Input.GetKey(downKey)) direction = -1;

        return direction * (speed + incrementSpeed) * Vector2.up;
    }

    private void MoveObject(Vector2 movement)
    {
        if (movement != Vector2.zero) Debug.Log(name + " : " + movement);
        rig.velocity = movement;
    }

    public void LongPaddle()
    {
        longPadle = 5;
        
        //Jika PowerUP Diambil 2x Hanya Mereset Durasi Waktu
        if (transform.localScale.y == normalSizePadle.y) 
            transform.localScale += Vector3.up * 2;
    }

    public void SpeedUpPaddle()
    {
        speedUpPadle = 5;

        //Jika PowerUP Diambil 2x Hanya Mereset Durasi Waktu
        if (incrementSpeed == 0)
            incrementSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball")
        {
            //Mengubah Warna Saat Terkena Bola
            StartCoroutine(changeColor());
        }
    }

    private IEnumerator changeColor()
    {
        GetComponent<SpriteRenderer>().color = hitColor;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
