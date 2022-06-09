using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private int speed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        speed = OptionStaticScript.GetPaddleSpeed();

        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        int direction = 0;

        if (Input.GetKey(upKey)) direction = 1;
        else if (Input.GetKey(downKey)) direction = -1;

        return direction * speed * Vector2.up;
    }

    private void MoveObject(Vector2 movement)
    {
        if (movement != Vector2.zero) Debug.Log(name + " : " + movement);
        rig.velocity = movement;
    }
}
