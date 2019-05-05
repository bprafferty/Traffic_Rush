using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automaticMovement : MonoBehaviour
{

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
     public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float motorForce = 10;
    public Transform goalZonePrefab;

    

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }
    private void Accelerate()
    {
        frontDriverW.motorTorque = motorForce;
        frontPassengerW.motorTorque = motorForce;
    }
    private void FixedUpdate()
    {
        if (transform.position.z < 5)
        {
            Debug.Log("teleport");
            transform.position = new Vector3(transform.position.x, transform.position.y, 195.0f);
        }

        //UpdateWheelPoses();
        Accelerate();

        if (transform.position.y < -.5)
        {
            Destroy(gameObject);
            Debug.Log("destroyed");
        }
 

    }

    private void Start()
    {
        Transform goalZone = Instantiate(goalZonePrefab) as Transform;
        Physics.IgnoreCollision(goalZone.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void Update()
    {

    }


}
