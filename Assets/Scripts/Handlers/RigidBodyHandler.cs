using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyHandler
{

    private Rigidbody2D rb;
    private MovementStatus status;

    public RigidBodyHandler(Rigidbody2D rigidbody,  MovementStatus mStatus){
        this.rb = rigidbody;
        this.status = mStatus;
    }
    public void ApplyConstantForce(Vector2 dir){
        rb.AddForce(status.velocity * dir, ForceMode2D.Impulse);
    }
}
