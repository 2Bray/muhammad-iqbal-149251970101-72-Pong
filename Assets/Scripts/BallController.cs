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
        rig.velocity = startVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 startVelocity()
    {
        //Mengacak arah bola
        float dirX = Random.Range(0, 2) == 1 ? 6f : -6f;
        float dirY = Random.Range(-5f,5f);

        return new Vector2(dirX,dirY);
    }
}
