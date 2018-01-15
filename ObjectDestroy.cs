using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectDestroy : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
       
        if (Mathf.Abs(other.relativeVelocity.y) > 10.0f)
        {
            Destroy(this.gameObject);

        }
    }
}
