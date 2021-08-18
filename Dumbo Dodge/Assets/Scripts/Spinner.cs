using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float yValue = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yValue = 1 * Time.deltaTime * speed;
        transform.Rotate (0,yValue,0);
    }
}
