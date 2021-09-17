using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        { return; }

        float cycles = Time.time / period; // Continuously growing over time

        const float tau = Mathf.PI * 2;  //Constant value of 6.2
        float rawSineWave = Mathf.Sin(cycles * tau);   //giving values from -1 to 1
        movementFactor = (rawSineWave + 1f) / 2f;  //Recalculating for value of 0 to 1
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}
