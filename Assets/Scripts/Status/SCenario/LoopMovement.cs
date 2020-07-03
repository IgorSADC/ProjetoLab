using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovement : MonoBehaviour
{

   // private RigidBodyHandler rigidBodyHandler;

    public MovementStatus status;
    private float initialXPosition;
    private float cameraSize;
    private SpriteRenderer sprite;
    private float spriteSize;

    //for non looping images
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
       // rigidBodyHandler = new RigidBodyHandler(GetComponent<Rigidbody2D>(),status);
        initialXPosition = transform.position.x;
        cameraSize = Camera.main.orthographicSize*2f *Camera.main.aspect;
        sprite = GetComponent<SpriteRenderer>();
        spriteSize = sprite.bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
//rigidBodyHandler.ApplyConstantForce(-transform.right);
        transform.position -= Vector3.right * status.velocity;
        if(initialXPosition - transform.position.x >= spriteSize- (cameraSize + offset)){
            transform.position = new Vector3(initialXPosition, transform.position.y,transform.position.z);
        }
    }
}
