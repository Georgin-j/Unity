using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer render;
    Rigidbody rigid;
        [SerializeField] float timeToWait = 4f;

        private void Start() {
            render = GetComponent<MeshRenderer>();
            rigid = GetComponent<Rigidbody>(); 
            rigid.useGravity = false;
            render.enabled = false;
        }
    // Update is called once per frame
    void Update()
    {
    
        if (Time.time > timeToWait)
        {
            render.enabled = true;
            rigid.useGravity = true; 
        }
    }
}
