using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMessage : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Dumbo")
        {
        GetComponent<MeshRenderer>().material.color = Color.red;
        transform.gameObject.tag = "Hit";
   } 
    }
}
