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

    // Use this for initialization
    void Start()
    {
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
                                        if (!(this.transform.position.x == C.x))
                                        {
                                            this.transform.position = C;
                                        }
                                        else this.transform.position = D;
                                    }
                                }
                                else{
                                    // MOVE LEFT
                                    //BroadcastMessage("SwipeLeft");
                                    if (!(this.transform.position.x == E.x))
                                    {
                                        if (!(this.transform.position.x == C.x))
                                        {
                                            this.transform.position = C;
                                        }
                                        else this.transform.position = E;
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
                                            this.transform.position = new Vector3(transform.position.x, transform.position.y - ((speed * 0.75f) * Time.deltaTime), transform.position.z);
                                        }
                                        else
                                        {
                                            isPulando = false;
                                        }
                                    

                                    BroadcastMessage("SwipeUp");
                                }
                            }
                            else{
								// MOVE DOWN
								BroadcastMessage("SwipeDown");
							}
						}
						
					}
					
					break;
				}
			}
		}
		
	}
}