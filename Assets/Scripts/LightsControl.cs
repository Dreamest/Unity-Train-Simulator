using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsControl : MonoBehaviour
{
    public GameObject sun;
    private Light[] lights;
    private DayNightCycle dayNight;
    // Start is called before the first frame update
    void Start()
    {
        lights = gameObject.GetComponentsInChildren<Light>();
        dayNight = sun.GetComponent<DayNightCycle>();
        print(lights.Length);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Light light in lights)
            if(dayNight.isDay)
                light.enabled = false;
            else
                light.enabled = true;
    }
}
