using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int people;
    // Start is called before the first frame update
    void Start()
    {
        people = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPCFromA") || other.CompareTag("NPCFromB"))
        {
            people++;
        }
        // if(other.CompareTag("NPCFromB"))
        // {
        //     peopleB++;
        // }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("NPCFromA")|| other.CompareTag("NPCFromB"))
        {
            people--;
        }
        // if(other.CompareTag("NPCFromB"))
        // {
        //     peopleB--;
        // }
    }
}
