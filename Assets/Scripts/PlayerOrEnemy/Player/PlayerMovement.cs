using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public SaveData saveData;
    [HideInInspector]
    public Rigidbody2D myBody;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if ((Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0) &&
                (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0))
            {
                myBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime / Mathf.Sqrt(2);
            }
            else
                myBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        }
    }
}
