using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    private Animator animator;
    public int peopleInStation;
    private bool onA, onB;
     private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        peopleInStation = 0;
        onA = false;
        onB = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("UPlatformA"))
        {
            onA = true;
        }
        if(other.CompareTag("UPlatformB"))
        {
            onB = true;
        }
        if((other.CompareTag("NPCFromA") && onA) ||(other.CompareTag("NPCFromB") && onB))
        {
            peopleInStation++;
            Debug.Log("Enter " + peopleInStation);

        }
        if(peopleInStation > 0)
            animator.SetBool("Clear", false);
 
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("UPlatformA"))
        {
            onA = false;
        }
        if(other.CompareTag("UPlatformB"))
        {
            onB = false;
        }
        if((other.CompareTag("NPCFromA") && onA) ||(other.CompareTag("NPCFromB") && onB))
        {
            
            peopleInStation--;
            if(peopleInStation == 0)
                animator.SetBool("Clear", true);
            // Debug.Log("Exit " + peopleInStation);
        }

    }

    public int getPeople()
    {
        int n = transform.childCount;
        int people = 0;
        for (int i = 0; i < n; i++)
        {
            if(transform.GetChild(i).gameObject.tag == "NPCFromA" || transform.GetChild(i).gameObject.tag == "NPCFromA")
            {
                people++;
            }
        }
        return people;
    }
}
