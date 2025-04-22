using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AWSIM;

namespace AWSIM.TrafficSimulation{
public class Reward : MonoBehaviour
{private float[]results = new float[7]; 
private publisher pub;
    // Start is called before the first frame update
    void Start()
    {pub = GetComponent<publisher>();
        LeftLane.reward=0f;
        LeftLane.penalty=-10f;
        
         RightLane.reward=0f;
        RightLane.penalty=-10f;
        
         npc.reward=0f;
        npc.penalty=-10f;
        
         bush.reward=0f;
        bush.penalty=-10f;
        
         tree.reward=0f;
        tree.penalty=-10f;
        
        carDetector.sreward=0f;
        carDetector.spenalty=-10f;
        
         carDetector.jreward=0f;
        carDetector.jpenalty=-10f;
        
        StopLine.reward=0f;
        StopLine.penalty=-10f;
        
           npcv.reward=0f;
        npcv.penalty=-10f;
    }

    // Update is called once per frame
    void Update()
    {
        results[0] =carDetector.jresult;   
        results[1] = (LeftLane.result ==  LeftLane.penalty || RightLane.result ==  LeftLane.penalty) ? LeftLane.penalty : LeftLane.reward;; 
        results[2] = npc.result;     
        results[3] = npcv.result;
        results[4] =     (tree.result==  tree.penalty|| bush.result ==  tree.penalty) ? tree.penalty : tree.reward;; 
      	results[5]=carDetector.sresult;
      	results[6]=StopLine.result;


        pub.publishMSG(results);
    }
}}
