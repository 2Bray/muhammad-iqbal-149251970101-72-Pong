using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        startVelocity();
    }

    public void startVelocity()
    {
        //Mengacak arah bola
        float dirX = Random.Range(0, 2) == 1 ? 6f : -6f;
        float dirY = Random.Range(-5f, 5f);

        rig.velocity = new Vector2(dirX, dirY);
    }
}
