using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrust = 1000f;
    [SerializeField] float turn = 1f; 
    Rigidbody rb;
    AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessorThrust();
        ProcessorRotation();
    }
    void ProcessorThrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(thrust * Time.deltaTime * Vector3.up);
            if (!ad.isPlaying)
            {
                ad.Play();
            }
        }
        else
        {
            ad.Stop();
        }
    }
    void ProcessorRotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotation(turn);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotation(-turn);
        }
    }

    void Rotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
