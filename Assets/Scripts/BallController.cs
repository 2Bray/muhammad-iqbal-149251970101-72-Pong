using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] Text readyText;

    private SpriteRenderer sr;
    private Rigidbody2D rig;
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = OptionStaticScript.Instance.GetBallSpeed();

        sr = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(startVelocity());
    }

    public IEnumerator startVelocity()
    {
        //Mereset Bola
        rig.velocity = Vector2.zero;
        transform.position = new Vector3(0, 0, transform.position.z);

        sr.color = Color.white;

        //Hitung Mundur
        readyText.gameObject.SetActive(true);
        readyText.text = "Ready !";
        yield return new WaitForSeconds(1f);
        readyText.text = "Set !!";
        yield return new WaitForSeconds(1f);
        readyText.text = "Go !!!";
        yield return new WaitForSeconds(1f);
        readyText.gameObject.SetActive(false);


        //Mengacak arah bola
        float dirX = Random.Range(0, 2) == 1 ? speed : -speed;
        float dirY = Random.Range(-5f, 5f);

        rig.velocity = new Vector2(dirX, dirY);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void ActivatePUInvisible(Color color)
    {
        sr.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.color = Color.white;
    }
}
