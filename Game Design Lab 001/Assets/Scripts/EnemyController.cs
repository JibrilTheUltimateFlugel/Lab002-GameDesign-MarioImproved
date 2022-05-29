using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float originalX; // Original horizontal position of the enemy
    private float maxOffset = 5.0f; // Max offset of patrolling to the left and the right
    private float enemyPatroltime = 5.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;

    // For Flipping Goomba Sprite
    private SpriteRenderer goombaSprite;
    private bool faceRightGoom = true; //default = Right

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        goombaSprite = GetComponent<SpriteRenderer>(); // get goomba sprite
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity(); // call helper function
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0); // divide supposed distance travelled by enemy patrolling time to obtain velocity
    }

    void MoveGomba() // function to move enemy position
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime); // original position + velocity x delta time
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset) // if the distance between the current position of the goomba and its original position is still below the maximum offset
        {// move goomba
            MoveGomba();
        }
        else
        {
            // change direction of movement to the opposite side
            if (faceRightGoom)
            {
                faceRightGoom = false;
                goombaSprite.flipX = true;
            }
            else if(!faceRightGoom)
            {
                faceRightGoom = true;
                goombaSprite.flipX = false;
            }
            moveRight *= -1;
            ComputeVelocity();
            MoveGomba();
        }
    }
}
