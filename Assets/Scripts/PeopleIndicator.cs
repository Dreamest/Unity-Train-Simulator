using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PeopleIndicator : MonoBehaviour
{
    public TMP_Text peopleOnA;
    public TMP_Text peopleOnB;
    public TMP_Text peopleOnTrain;
    public GameObject platformA;
    public GameObject platformB;

    // public GameObject platformB;
    public GameObject train;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        peopleOnA.text = "People on platform A: " + platformA.GetComponent<Platform>().people;
        peopleOnB.text = "People on platform B: " + platformB.GetComponent<Platform>().people;
        peopleOnTrain.text = "People on the train: " + train.GetComponent<TrainMovement>().getPeople();

    }
}
