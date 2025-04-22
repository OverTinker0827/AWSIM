using UnityEngine;

public class npcv : MonoBehaviour
{public static float result;
	public static float reward;
	public static float penalty;
	private static int col=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(col==0){
       result=reward;
       
       }else{
       result=penalty;
       }
         
    }

    // Collision detection
    void OnCollisionEnter(Collision collision)
    {
    Debug.Log(collision.gameObject.name);
    if(collision.gameObject.name=="Lexus RX450h 2015 Sample Sensor"){
       col++;}
    }
    void OnCollisionExit(Collision collision)
    {
       if(collision.gameObject.name=="Lexus RX450h 2015 Sample Sensor"){
       col--;}
    }
}

