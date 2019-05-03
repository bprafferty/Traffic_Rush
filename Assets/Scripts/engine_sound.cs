using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engine_sound : MonoBehaviour
{ //old

    public float topspeed = 100f;
    private float currentSpeed = 0;
    private float pitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        pitch = currentSpeed / topspeed;
        GetComponent<AudioSource>().pitch = pitch;
        
    }
}
