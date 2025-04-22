using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROS2;
using std_msgs.msg;
public class publisher : MonoBehaviour
{
    // Start is called before the first frame update
    private ROS2UnityCore ros2Unity ;
    private IPublisher<std_msgs.msg.Float32MultiArray> pub;
    private ROS2Node ros2Node;
    void Start()
    {   
    	ros2Unity= new ROS2UnityCore();
        if (ros2Unity.Ok()) {
    ros2Node = ros2Unity.CreateNode("reward");
pub = ros2Node.CreatePublisher<Float32MultiArray>("/penalties");
    }
}
    // Update is called once per frame
    void Update()
    {   
        // Publisher<std_msgs.msg.String> chatter_pub=node.CreatePublisher<std_msgs.msg.String>("/test_topic/yay");
        // std_msgs.msg.String msg = new std_msgs.msg.String();
        // msg.Data = "yo this fucking workedd";
        // chatter_pub.Publish(msg);   
        // Debug.Log("Publishing");
    }
     public void publishMSG(float[] arr){
       Float32MultiArray msg = new Float32MultiArray
            {
                Data = arr
            };
            
            pub.Publish(msg);
    }
}
