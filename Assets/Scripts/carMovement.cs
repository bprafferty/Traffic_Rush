using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carMovement:MonoBehaviour
{
    public Animator animatorLift;
    public AudioSource speedSong;
    public AudioSource breakSong;
   public AudioSource crashSong;

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    public int scoreStart;


    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    private float maxSteerAngle = 30;
    private float motorForce = 1;
    public float constantMotorFoce = 1000;
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
            //speedSong.time = 2.5f;
            //speedSong.Play();
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
            frontDriverW.motorTorque = m_verticalInput * motorForce;
            frontPassengerW.motorTorque = m_verticalInput * motorForce;

        }
        else if (m_verticalInput < -0.01)
        {


            breakSong.time = 1.0f;
            breakSong.Play();
            frontDriverW.brakeTorque = Brakes;
            frontPassengerW.brakeTorque = Brakes;
        }
        else
        {
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
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

    void OnCollisionEnter(Collision collision)
    {
        crashSong.time = 1f;
        crashSong.Play();
        Debug.Log("crash");
        if ((collision.gameObject.name != "MiniRamps") && (collision.gameObject.name != "road_0001") && (collision.gameObject.name != "road_0001 (1)"))
        {
            gameManaging.gameInstance.savedScore = scoreStart;
            Application.LoadLevel(Application.loadedLevel);
        }


    }
    private void Update()
    {
        if (crashSong.time > 2f)
        {
            crashSong.Stop();
            
        }
        if(breakSong.time > 2f)
        {
            breakSong.Stop();
        }
        //if (!(m_verticalInput > 0.01)) 
        //{
            //speedSong.Stop();
        //}

        if (transform.position.z > 185)
        {
            Debug.Log("End Zone");
            sceneManaging foo = new sceneManaging();
            foo.goToNextScene();
        }

        if (transform.position.z > 20)
        {
            Invoke("AnimStart", 0.0f);
        }
    }


    void AnimStart()
    {
        animatorLift.SetBool("animationBoolean", true);
        
    }

    private void Start()
    {
        animatorLift.enabled = true;
        animatorLift.SetBool("animationBoolean", false);

        scoreStart = gameManaging.gameInstance.savedScore;
    }

    private void FixedUpdate()
    {
        //mainSong.Play();
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }


}
