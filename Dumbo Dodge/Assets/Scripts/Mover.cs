using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Instructions();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Instructions()
{
    Debug.Log("Hello and welcome to Hell");
}

    void Movement()
    {
        float zValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float xValue = (Input.GetAxis("Vertical") * Time.deltaTime * speed);

        transform.Translate(xValue,0,zValue);
    }
}
