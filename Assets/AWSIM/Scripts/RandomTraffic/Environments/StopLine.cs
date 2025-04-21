using UnityEngine;
using AWSIM;
namespace AWSIM.TrafficSimulation
{
    /// <summary>
    /// Stop line component.
    /// </summary>
    public class StopLine : MonoBehaviour
    {	public static float result;
    public static float reward;
    public static float penalty;
    private static int count=0;
    private  bool redLight=false;
    private bool violation=false;
        [SerializeField, Tooltip("Line data consists of 2 points.")]
        private Vector3[] points = new Vector3[2];
        [SerializeField, Tooltip("Indicates whether the stop sign exists.")] 
        private bool hasStopSign = false;
        [SerializeField, Tooltip("Traffic light ")]
        private TrafficLight trafficLight;
	public bool on_it=false;
        /// <summary>
        /// Get line data consists of 2 points.
        /// </summary>
        public Vector3[] Points => points;

        /// <summary>
        /// Get center point of the stop line.
        /// </summary>
        public Vector3 CenterPoint => (points[0] + points[1]) / 2f;

        public TrafficLight TrafficLight
        {
            get => trafficLight;
            set => trafficLight = value;
        }

        public bool HasStopSign
        {
            get => hasStopSign;
            set => hasStopSign = value;
        }
  private void OnTriggerEnter(Collider other)
        {if(other.gameObject.name!="Collider"){return;}
        on_it=true;
        }
        private void OnTriggerExit(Collider other)
        {if(other.gameObject.name!="Collider"){return;}
        on_it=false;
           if(violation){ count--;
            violation=false;}
}
        void Update()
        {
        if(on_it)
        {
        
       
          
	if(trafficLight!=null)
	{
	TrafficLight.BulbData[] bulbData = trafficLight.GetBulbData();

foreach (var bulb in bulbData)
{
    if (bulb.Color == TrafficLight.BulbColor.RED && 
        (bulb.Status == TrafficLight.BulbStatus.SOLID_ON || 
         bulb.Status == TrafficLight.BulbStatus.FLASHING))
    {
         redLight=true;
        break;
    }
}
	}
            
            bool stopSignViolation = hasStopSign;

            if (redLight || stopSignViolation)
            {
                if(!violation){count++;
                violation=true;}
               
            }else{
           if(violation){ count--;
            violation=false;}
            }
        
        
        }
      
        
        if(count==0){
        result=reward;
        }else{
        result=penalty;
        }
        
        
        
        }
        public static StopLine Create(Vector3 p1, Vector3 p2)
        {
            var gameObject = new GameObject("StopLine", typeof(StopLine));
            gameObject.transform.position = p1;
            var stopLine = gameObject.GetComponent<StopLine>();
            stopLine.points[0] = p1;
            stopLine.points[1] = p2;
            return stopLine;
        }
    }
}
