using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float distanceTravelled;
        [SerializeField] Shoot shoot;
     
        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                var a =shoot.GetComponent<Shoot>();
                if(a!=null){
                    a.enabled = false;
                }
                 
                pathCreator.pathUpdated += OnPathChanged;
               
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                
                checkComplete();
                //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
               
              //  transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
       void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
        void shootActive(){
            Shoot a=shoot.GetComponent<Shoot>();
             a.enabled=true;
        }
         public void checkComplete(){
            if(distanceTravelled>=pathCreator.path.length){
                  Invoke("shootActive",RamdomFiringRate());
              // transform.position=Vector2.MoveTowards(transform.position,new Vector2(0,30),2.5f*Time.deltaTime);
                return;
            }else{
               transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            }
            
        }
        public  float RamdomFiringRate(){
        float FiringRateTime= UnityEngine.Random.Range(1 ,50.0f);
        return FiringRateTime;
    }
       
    }
       
}