using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] Text readyText;
    private Rigidbody2D rig;
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = OptionStaticScript.GetBallSpeed();

        rig = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        rig.velocity = startVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 startVelocity()
=======
        StartCoroutine(startVelocity());
    }

    public IEnumerator startVelocity()
>>>>>>> Stashed changes
    {
        //Mereset Posisi Bola
        rig.velocity = Vector2.zero;
        transform.position = new Vector3(0, 0, transform.position.z);

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
<<<<<<< Updated upstream
        float dirX = Random.Range(0, 2) == 1 ? 6f : -6f;
        float dirY = Random.Range(-5f,5f);
=======
        float dirX = Random.Range(0, 2) == 1 ? speed : -speed;
        float dirY = Random.Range(-5f, 5f);
>>>>>>> Stashed changes

        return new Vector2(dirX,dirY);
    }
}
