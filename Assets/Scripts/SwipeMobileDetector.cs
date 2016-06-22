using UnityEngine;
using System.Collections;

public class SwipeMobileDetector : MonoBehaviour {
    public static SwipeMobileDetector instance;
    public bool isPulando = false, isSubindo = false, isDescendo = false;
    public float speed = 0f;

    private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

    private bool start = false;
    private Vector3 E, C, D;

    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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

    void FixedUpdate()
    {
        if (isPulando)
        {
            if (Player.transform.position.y < 20 && isSubindo)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + ((speed + 1) * Time.deltaTime), Player.transform.position.z);
            }
            else if (Player.transform.position.y > 20 || isDescendo)
            {
                if (Player.transform.position.y > 0)
                {
                    isSubindo = false;
                    isDescendo = true;
                }
                else isDescendo = false;
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - ((speed + 3) * Time.deltaTime), Player.transform.position.z);
            }
            else
            {
                isPulando = false;
            }


        }
    }

    // Update is called once per frame
    void Update () {
		
		if (Input.touchCount > 0){
			
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
					
				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;
					
				case TouchPhase.Ended :
					
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}
						
						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
                                    // MOVE RIGHT
                                    //BroadcastMessage("SwipeRight");
                                    if (!(this.transform.position.x == D.x))
                                    {
                                        if (!(Player.transform.position.x == C.x) && Player.transform.position.x == E.x)
                                        {
                                            Player.transform.position = new Vector3(C.x, this.transform.position.y, this.transform.position.z);
                                        }
                                        
                                        else Player.transform.position = new Vector3(D.x, this.transform.position.y, this.transform.position.z);
                                    }
                                }
                                else{
                                    // MOVE LEFT
                                    //BroadcastMessage("SwipeLeft");
                                    if (!(Player.transform.position.x == E.x))
                                    {
                                        if (!(Player.transform.position.x == C.x) && Player.transform.position.x == D.x)
                                        {
                                            Player.transform.position = new Vector3(C.x, this.transform.position.y, this.transform.position.z);
                                        }
                                        else Player.transform.position = new Vector3(E.x, this.transform.position.y, this.transform.position.z);
                                    }
                                    
                                }
						}
						
						if(swipeType.y != 0.0f ){
							if(swipeType.y > 0.0f){
                                    Debug.Log("swipe up");
                                    if (!isPulando)
                                    {
                                        isPulando = true;
                                        isSubindo = true;
                                    }
                                 
                            }
                            else{
								// MOVE DOWN
								//BroadcastMessage("SwipeDown");
							}
						}
						
					}
					
					break;
				}
			}
		}
		
	}
}