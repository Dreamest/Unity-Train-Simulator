using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        if(this.tag == "randomizerA")
        {
            moveA();
        }
        if(this.tag == "randomizerB")
        {
            moveB();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPCFromB") && this.tag == "randomizerA" && character.transform.parent == this.transform.parent)
        {
            moveA();
        }
        if(other.CompareTag("NPCFromA") && this.tag == "randomizerB" && character.transform.parent == this.transform.parent)
        {
            moveB();
        }
    }

    private void moveA()
    {
        Vector3 newPosition = new Vector3();
        float xmin = 226.2f, xmax = 228.7f, zmin = 85.4f, zmax = 142.2f;
        newPosition.x = Random.Range(xmin, xmax);
        newPosition.z = Random.Range(zmin, zmax);
        newPosition.y = 123f;
        transform.position = newPosition;

    }

    private void moveB()
    {
        Vector3 newPosition = new Vector3();
        float xmin = 175.7f, xmax = 177.9f, zmin = 306f, zmax = 361.8f;
        newPosition.x = Random.Range(xmin, xmax);
        newPosition.z = Random.Range(zmin, zmax);
        newPosition.y = 123f;
        transform.position = newPosition;
    }
}
