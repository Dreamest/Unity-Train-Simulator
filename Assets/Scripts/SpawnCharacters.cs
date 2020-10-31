using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SpawnCharacters : MonoBehaviour
{
    public GameObject npcA, npcB;
    public GameObject trainDoor1;
    public GameObject trainDoor2;
    public GameObject trainDoor3;
    public GameObject trainDoor4;
    public GameObject train;


    private int peopleOnA, peopleOnB;
    // Start is called before the first frame update
    void Start()
    {
        //Get details from the sliders as to how many people to add to each platform 
        peopleOnA = PlayerPrefs.GetInt("Platform A Slider");
        peopleOnB = PlayerPrefs.GetInt("Platform B Slider");


        //Spawn people
        SpawnA(peopleOnA);
        SpawnB(peopleOnB);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnA(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //Randomize position within platform A
            Vector3 position = new Vector3();
            float xmin = 226.2f, xmax = 228.7f, zmin = 85.4f, zmax = 142.2f;
            position.x = Random.Range(xmin, xmax);
            position.z = Random.Range(zmin, zmax);
            position.y = 123f;

            //The first child is the actual character, get its script
            NPCMovement script = npcA.transform.GetChild(0).gameObject.GetComponent<NPCMovement>();
            //Initialize script elements
            script.trainDoor1 = trainDoor1;
            script.trainDoor2 = trainDoor2;
            script.trainDoor3 = trainDoor3;
            script.trainDoor4 = trainDoor4;
            script.train = train;
            //With the script intact - instaniate the character
            GameObject newChar = Instantiate(npcA, position, Quaternion.identity);
        }
    }

    void SpawnB(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //Randomize position within platform B
            Vector3 position = new Vector3();
            float xmin = 175.7f, xmax = 177.9f, zmin = 306f, zmax = 361.8f;
            position.x = Random.Range(xmin, xmax);
            position.z = Random.Range(zmin, zmax);
            position.y = 123f;

            //The first child is the actual character, get its script
            NPCMovement script = npcB.transform.GetChild(0).gameObject.GetComponent<NPCMovement>();
            //Initialize script elements
            script.trainDoor1 = trainDoor1;
            script.trainDoor2 = trainDoor2;
            script.trainDoor3 = trainDoor3;
            script.trainDoor4 = trainDoor4;
            script.train = train;
            //With the script intact - instaniate the character
            GameObject newChar = Instantiate(npcB, position, Quaternion.identity);
        }
    }


}
