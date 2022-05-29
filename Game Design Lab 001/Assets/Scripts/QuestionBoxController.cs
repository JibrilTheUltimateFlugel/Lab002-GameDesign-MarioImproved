using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxController : MonoBehaviour
{
    // References
    public Rigidbody2D rigidBody; //the ? Box rigid body
    public SpringJoint2D springJoint; //the ? Box spring joint
    public GameObject consummablePrefab; // the spawned mushroom prefab
    public SpriteRenderer spriteRenderer; // the ? Box sprite renderer
    public Sprite usedQuestionBox; // the sprite that indicates empty box instead of a question mark
    private bool hit = false; // initially the Box has not been hit

    void Start()
    {
        
    }

    void Update()
    {

    }
    // Box hit by player callback
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && !hit) // if the player comes into contact with the bottom part of the box and the box is still not hit
        {
            hit = true; //hit is now set to true since the box has been hit
            rigidBody.AddForce(new Vector2(0, rigidBody.mass * 50), ForceMode2D.Impulse); // add an Artificial force upwards, 10 times of the Rigid Body mass to ensure the box moves
            // spawn the mushroom prefab slightly above the box
            Instantiate(consummablePrefab, new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z), Quaternion.identity); //this.transform.position is the World Space coordinates
            // Call the Coroutine
            StartCoroutine(DisableHittable());
        }
    }

    // Coroutines functions
    bool ObjectMovedAndStopped() // Checker function to know when the box stops moving
    {
        return Mathf.Abs(rigidBody.velocity.magnitude) < 0.01;
    }

    // Coroutine
    IEnumerator DisableHittable()
    {
        if (!ObjectMovedAndStopped()) // if the checker function is still false, the box is still moving, yield to give control to unity to do other functions
        {
            yield return new WaitUntil(() => ObjectMovedAndStopped());
        }

        //continues here when the ObjectMovedAndStopped() returns true
        spriteRenderer.sprite = usedQuestionBox; // change sprite to be "used-box" sprite
        rigidBody.bodyType = RigidbodyType2D.Static; // make the box unaffected by Physics

        //reset box position wrt to Parent
        this.transform.localPosition = Vector3.zero;
        springJoint.enabled = false; // disable spring
    }

}
