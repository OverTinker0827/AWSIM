using UnityEngine;

public class bush : MonoBehaviour
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
       col++;
    }
    void OnCollisionExit(Collision collision)
    {
        col--;
    }
}

