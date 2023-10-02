using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);
        }
    }

    void FallDown()
    {
        Rigidbody rb = GetComponentInParent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }
}
