using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement:MonoBehaviour
{

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    private float maxSteerAngle = 30;
    private float motorForce = 2000;
    private float constantMotorFoce = 200;
    private int moving = 0;
    private float Brakes = 30000;

    //new
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");

       
    }   
    

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        //if(m_verticalInput > 0.01 || m_verticalInput < -0.01)
        if (m_verticalInput > 0.01)
        {
            frontDriverW.motorTorque = m_verticalInput * motorForce;
            frontPassengerW.motorTorque = m_verticalInput * motorForce;

        }
        else if (m_verticalInput < -0.01)
        {
            frontDriverW.brakeTorque = Brakes;
            frontPassengerW.brakeTorque = Brakes;
        }
        else
        {
            frontDriverW.motorTorque = constantMotorFoce;
            frontPassengerW.motorTorque = constantMotorFoce;
        }
    }

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




    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }


}
