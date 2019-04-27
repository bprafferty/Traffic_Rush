using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{

    public GameObject wheel_FR;
    public GameObject wheel_FL;
    public GameObject wheel_BR;
    public GameObject wheel_BL;

    public WheelCollider W_FL;
    public WheelCollider W_FR;
    public WheelCollider W_BL;
    public WheelCollider W_BR;

    public float Torque = 1000f;
    public float lowestAngle = 20f;
    public float highestAngle = 40f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        CarMovement();
    }


    void CarMovement()
    {
        W_BL.motorTorque = Torque * Input.GetAxis("Vertical");
        W_BL.motorTorque = Torque * Input.GetAxis("Vertical");

        float speedfactor = this.GetComponent<Rigidbody>().velocity.magnitude / lowestAngle;
        float currentAngle = Mathf.Lerp(lowestAngle, highestAngle, speedfactor);

        currentAngle = Input.GetAxis("Horizontal");

        W_FL.steerAngle = currentAngle;
        W_FR.steerAngle = currentAngle;

    }
}
