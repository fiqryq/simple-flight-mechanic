namespace PathCreation.Examples
{
    public class FlightMechanic : MonoBehaviour
    {
        public PathCreator pathCreator;
        public PathCreator pesawatParkirOut;
        public PathCreator pesawatParkirIn;
        public PathCreator pesawatTakeOff;
        public PathCreator pesawatLanding;

        public GameObject kameraSatu;
        public GameObject kameraDua;

        public GameObject ParkirGaruda;
        public GameObject CameraPesawatGaruda;

        [SerializeField]
        Camera onCameraGaruda;

        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        void Start() {
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }
        
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void berhenti()
        {
            speed = 0;
        }

        public void kurangKecepatan()
        {
            speed = speed-1;
        }
        public void tambahKecepatan()
        {
            speed = speed + 2;
        }

        public void parkirOut()
        {
            distanceTravelled = 0;
            pathCreator = pesawatParkirOut;
        }

        public void takeOff()
        {
            speed = 1;
            distanceTravelled = 0;
            pathCreator = pesawatTakeOff;
            kameraSatu.SetActive(false);
            kameraDua.SetActive(true);
            onCameraGaruda.GetComponent<Camera>().enabled = true;
        }
    }
}