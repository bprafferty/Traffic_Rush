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
    public float loweststeerSpeed = 20f;
    public float loweststeerAngle = 70f;
    public float highestSteerAngle = 40f;



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
        rotateWheels();
        steerWheels();
    }


    void CarMovement()
    {
        W_BL.motorTorque = Torque * Input.GetAxis("Vertical");
        W_BL.motorTorque = Torque * Input.GetAxis("Vertical");

        float speedfactor = this.GetComponent<Rigidbody>().velocity.magnitude / loweststeerSpeed;
        float currentAngle = Mathf.Lerp(loweststeerAngle, highestSteerAngle, speedfactor);

        currentAngle *= Input.GetAxis("Horizontal");

        W_FL.steerAngle = currentAngle;
        W_FR.steerAngle = currentAngle;

    }

    void rotateWheels()
    {
        wheel_BL.gameObject.transform.Rotate(W_BL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheel_BR.gameObject.transform.Rotate(W_BR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }

    void steerWheels()
    {
        Vector3 tmp;
        tmp = wheel_FR.transform.localEulerAngles;
        tmp.y = W_FR.steerAngle;
        wheel_FR.transform.localEulerAngles = tmp;


        tmp = wheel_FL.transform.localEulerAngles;
        tmp.y = W_FL.steerAngle;
        wheel_FL.transform.localEulerAngles = tmp;
    }
}
