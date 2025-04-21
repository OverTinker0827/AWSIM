using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDetector : MonoBehaviour
{
    public float speedThreshold = 15.0f; // Speed threshold to detect the car
    public float JerkThreshold = 2.0f; // Jerk threshold to detect the car
    // Start is called before the first frame update
    public Rigidbody rigidbody;
    private float prevVelocity=0.0f;
    private float prevAcceleration=0.0f;
	public static float sresult;
	public static float sreward;
	public static float spenalty;
	
	public static float jresult;
	public static float jreward;
	public static float jpenalty;
    public publisher pub;

    void Start()
    {
            if (rigidbody == null)
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.time % 2 < 0.01f && rigidbody.velocity.magnitude > speedThreshold) {
            sresult=spenalty;
        }else{
        sresult=sreward;
        }
        float Jerk=((rigidbody.velocity.magnitude - prevVelocity)-prevAcceleration) / Time.deltaTime * 0.01f;
        if(Jerk>JerkThreshold) {
           jresult=jpenalty;
        }else{
         jresult=jreward;
        }
        prevAcceleration= (rigidbody.velocity.magnitude - prevVelocity) / Time.deltaTime;
        prevVelocity = rigidbody.velocity.magnitude;
    }
}
