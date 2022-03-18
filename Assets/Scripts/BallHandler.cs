using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallHandler : MonoBehaviour
{
    [SerializeField] private float detachDelay;
    [SerializeField] private float respawnDelay;    
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;

    GameObject ballInstance;
    private Rigidbody2D ballRb;
    private SpringJoint2D joint;
    private Camera cam;

    private bool moveAllowed;
    private bool isDragging;  //useful to avoid the fact that if we tap the ball, it falls  
    void Start()
    {
        cam = Camera.main;
        SpawnNewBall();
    }

    void Update()
    {
        if (ballRb == null)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                
                RaycastHit2D hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                hit = Physics2D.GetRayIntersection(ray);

                if (hit)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                       moveAllowed = true;
                    }
                        
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    isDragging = true;
                    ballRb.isKinematic = true;
                    ballRb.position = new Vector2(touchPos.x, touchPos.y);
                }
            }

            if(touch.phase == TouchPhase.Stationary && isDragging)
            {
                ballRb.position = new Vector2(touchPos.x, touchPos.y);
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (isDragging)
                {
                    LaunchBall();
                }

                isDragging = false;

                moveAllowed = false;
                return;
            }
        }
    }

        void LaunchBall()
        {
            ballInstance.GetComponent<Ball>().isLaunched = true;
            ballRb.isKinematic = false;
            ballRb = null;

            Invoke("DetachBall", detachDelay);


        }

        void DetachBall()
        {
            joint.enabled = false;
            joint = null;
            Invoke(nameof(SpawnNewBall), respawnDelay);

        }

        void SpawnNewBall()
        {
            ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
            ballInstance.GetComponent<Ball>().isLaunched = false;
            ballRb = ballInstance.GetComponent<Rigidbody2D>();
            joint = ballInstance.GetComponent<SpringJoint2D>();
            joint.connectedBody = pivot;


        }
    
}
