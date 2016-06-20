using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour {
    public static SwipeDetector instance;
    public bool isPulando = false, isSubindo = false, isDescendo = false;
    public float speed = 0f;

    private const int mMessageWidth  = 200;
	private const int mMessageHeight = 64;
	
	private readonly Vector2 mXAxis = new Vector2(1, 0);
	private readonly Vector2 mYAxis = new Vector2(0, 1);

	// The angle range for detecting swipe
	private const float mAngleRange = 30;
	
	// To recognize as swipe user should at lease swipe for this many pixels
	private const float mMinSwipeDist = 50.0f;
	
	// To recognize as a swipe the velocity of the swipe
	// should be at least mMinVelocity
	// Reduce or increase to control the swipe speed
	private const float mMinVelocity  = 400.0f;
	private Vector2 mStartPosition;
	private float mSwipeStartTime;

    private bool start = false;
    private Vector3 E, C, D;
	
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        E = new Vector3(24, 0, 0);
        C = new Vector3(14, 0, 0);
        D = new Vector3(4, 0, 0);

    }

    public void GameStarted()
    {
        start = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPulando)
        {
            if (this.transform.position.y < 10 && isSubindo)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            }
            else if (this.transform.position.y > 10 || isDescendo)
            {
                if (this.transform.position.y > 0)
                {
                    isSubindo = false;
                    isDescendo = true;
                }
                else isDescendo = false;
                this.transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
            }
            else
            {
                isPulando = false;
            }
        }

        // Mouse button down, possible chance for a swipe
        if (Input.GetMouseButtonDown(0)) {
			// Record start time and position
			mStartPosition = new Vector2(Input.mousePosition.x,
			                             Input.mousePosition.y);
			mSwipeStartTime = Time.time;
		}
		
		// Mouse button up, possible chance for a swipe
		if (Input.GetMouseButtonUp(0)) {
			float deltaTime = Time.time - mSwipeStartTime;
			
			Vector2 endPosition  = new Vector2(Input.mousePosition.x,
			                                   Input.mousePosition.y);
			Vector2 swipeVector = endPosition - mStartPosition;
			
			float velocity = swipeVector.magnitude/deltaTime;

			if (velocity > mMinVelocity &&
			    swipeVector.magnitude > mMinSwipeDist) {
				// if the swipe has enough velocity and enough distance
				
				swipeVector.Normalize();
				
				float angleOfSwipe = Vector2.Dot(swipeVector, mXAxis);
				angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;


				// Detect left and right swipe
				if ((angleOfSwipe < mAngleRange) && start) {
					OnSwipeRight();
				} else if (((180.0f - angleOfSwipe) < mAngleRange) && start) {
					OnSwipeLeft();
				} else {
					// Detect top and bottom swipe
					angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
					angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
					if ((angleOfSwipe < mAngleRange)&& start) {
						OnSwipeTop();
					} else if (((180.0f - angleOfSwipe) < mAngleRange)&& start) {
						OnSwipeBottom();
					} else {
						// no swipe detected
					}
				}
			}
		}
	}

	
	private void OnSwipeLeft() {
        /*Debug.Log ("swipe left");
		BroadcastMessage("SwipeLeft");*/
        if (!(this.transform.position.x == E.x))
        {
            if (!(this.transform.position.x == C.x))
            {
                this.transform.position = C;
            }
            else this.transform.position = E;
        }
        
	}
	
	private void OnSwipeRight() {
        /*Debug.Log ("swipe right");
		BroadcastMessage("SwipeRight");*/
        if (!(this.transform.position.x == D.x))
        {
            if (!(this.transform.position.x == C.x))
            {
                this.transform.position = C;
            }
            else this.transform.position = D;
        }
    }
	
	private void OnSwipeTop() {
		Debug.Log ("swipe up");
        if (!isPulando)
        {
            isPulando = true;
            isSubindo = true;
        }

        Debug.Log("swipe up");

    }

    private void OnSwipeBottom() {
		Debug.Log ("swipe down");
		BroadcastMessage("SwipeDown");
	}
}