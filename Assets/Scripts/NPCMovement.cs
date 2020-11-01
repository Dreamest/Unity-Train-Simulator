using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject self;
    public GameObject trainDoor1;
    public GameObject trainDoor2;
    public GameObject trainDoor3;
    public GameObject trainDoor4;
    public GameObject train;
    public GameObject parent;
    public GameObject randomizerA;
    public GameObject randomizerB;
    private List<GameObject> allDoors;
    private UnityEngine.AI.NavMeshAgent agent;
    private CharacterController controller;
    private Animator animator;
    private bool validator, atA, mover, firstTime;
    private Vector3 destination;
    private float timerA, timerB;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updatePosition = true;
        agent.updateRotation = true;
        allDoors = new List<GameObject>();
        allDoors.Add(trainDoor1);
        allDoors.Add(trainDoor2);
        allDoors.Add(trainDoor3);
        allDoors.Add(trainDoor4);
        validator = false;
        atA = tag == "NPCFromA";
        timerA = 0f;
        timerB = 0f;
        firstTime = false;
        Physics.IgnoreLayerCollision(transform.gameObject.layer, transform.gameObject.layer, true); //Test this
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) //actually move only on walk animation
        {
            if (agent.enabled)
            {
                if (mover)
                    destination = closestDoor().transform.position;
                else if (tag == "NPCFromA")
                    destination = randomizerB.transform.position;
                else
                    destination = randomizerA.transform.position;

                agent.SetDestination(destination);
                controller.Move(agent.desiredVelocity.normalized * agent.speed * Time.deltaTime);
                agent.velocity = controller.velocity;
            }

        }

        //There's a 2 seconds window between reaching the place on the platform to be wanting to get on the train again.
        if (timerA > 0f)
        {
            timerA -= Time.deltaTime;
            if (timerA < 8f)
            {
                tag = "NPCFromA";
                timerA = 0f;
            }
        }
        if (timerB > 0f)
        {
            timerB -= Time.deltaTime;
            if (timerB < 8f)
            {
                tag = "NPCFromB";
                timerB = 0f;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("train") &&
                     ((tag == "NPCFromA" && atA) || (tag == "NPCFromB" && !atA)))
        {
            Debug.Log("Moving towards train");

            destination = closestDoor().transform.position;
            animator.SetTrigger("walk");
            mover = true;

        }
        //When reaching train, get inside
        if (other.CompareTag("train door") && ((tag == "NPCFromA" && atA) || (tag == "NPCFromB" && !atA)))
        {
            transform.position -= new Vector3(0f, 43f, 0f); //Move to underground platform
            transform.SetParent(train.transform);
            validator = true;
            animator.SetTrigger("idle");
            agent.enabled = false;
            // agent.enabled = true;
            firstTime = true;
            animator.enabled = false;

        }

        //Upon leaving the train, move towards a random position on the platform
        if (other.CompareTag("UPlatformB") && tag == "NPCFromA")
        {
            Debug.Log("Moving towards randomizer B");

            destination = randomizerB.transform.position;
            animator.SetTrigger("walk");
            mover = false;
        }
        if (other.CompareTag("UPlatformA") && tag == "NPCFromB")
        {
            Debug.Log("Moving towards randomizer A");

            destination = randomizerA.transform.position;
            animator.SetTrigger("walk");
            mover = false;
        }

        //Upon reaching random target, stop moving and start timer to change tag
        if (other.CompareTag("randomizerB") && tag == "NPCFromA" && firstTime)
        {
            Debug.Log("Arrived randomizer B");

            animator.SetTrigger("idle");
            timerB = 10f;
            firstTime = false;
        }

        if (other.CompareTag("randomizerA") && tag == "NPCFromB" && firstTime)
        {
            Debug.Log("Arrived randomizer A");

            animator.SetTrigger("idle");
            timerA = 10f;
            firstTime = false;
        }
    }

    void OnTriggerStay(Collider other)
    {

        //move from platform to train when it arrives

        //On lower platform, only leave the train when it's in idle mode
        if (validator &&
                ((other.CompareTag("LPlatformA") && tag == "NPCFromB") || (other.CompareTag("LPlatformB") && tag == "NPCFromA")) &&
                 (train.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle A") || train.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle B")))
        //If I'm from the opposite station and the train is in idle state
        {
            transform.SetParent(parent.transform);
            transform.position += new Vector3(0f, 43.3f, 0f);
            atA = !atA;
            validator = false; //ensures this happens only once
            // agent.enabled = false;
            agent.enabled = true;
            animator.enabled = true;
        }
    }
    private GameObject closestDoor()
    {
        GameObject closest = null;
        float bestDistance = 2000f;
        foreach (GameObject door in allDoors)
        {
            float currentDistance = Vector3.Distance(door.transform.position, transform.position);

            if (bestDistance > currentDistance)
            {
                closest = door;
                bestDistance = currentDistance;
            }
        }
        return closest;
    }


}
