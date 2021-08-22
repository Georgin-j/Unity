using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrust = 1000f;
    [SerializeField] float turn = 1f;
    [SerializeField] AudioClip rocket;

    [SerializeField] ParticleSystem thruster;
    [SerializeField] ParticleSystem rightTurn;
    [SerializeField] ParticleSystem leftTurn;

    Rigidbody rb;
    AudioSource ad;

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessorRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftThrusting();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RightThrusting();
        }
        else
        {
            StopParticles();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(thrust * Time.deltaTime * Vector3.up);
        if (!ad.isPlaying)
        {
            ad.PlayOneShot(rocket);
        }
        if (!thruster.isEmitting)
        {
            thruster.Play();
        }
    }

    void StopThrusting()
    {
        ad.Stop();
        thruster.Stop();
    }

    void LeftThrusting()
    {
        Rotation(turn);
        if (!leftTurn.isPlaying)
        {
            leftTurn.Play();
        }
    }

    void RightThrusting()
    {
        Rotation(-turn);
        if (!rightTurn.isPlaying)
        {
            rightTurn.Play();
        }
    }

    private void StopParticles()
    {
        leftTurn.Stop();
        rightTurn.Stop();
    }
 
    void Rotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
