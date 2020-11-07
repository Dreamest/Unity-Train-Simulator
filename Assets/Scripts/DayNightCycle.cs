using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private float day_length; 
    public bool isDay;
    // Start is called before the first frame update
    void Start()
    {
        day_length = PlayerPrefs.GetFloat("day_length");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * day_length);
        transform.LookAt(Vector3.zero);
        if(transform.position.y >= 80)
            isDay = true;
        else
            isDay = false;
    }
}


