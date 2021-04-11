using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //coded by: Emily Flood
    //this code was inspired by this tutorial from PekkeDev's YouTube tutorial
    //https://www.youtube.com/watch?v=e14JB5Ei6mA

    // Start is called before the first frame update
    [SerializeField]
    [Range(2, 12)]      //Slider

    public Animator anim1;

    private float speed = 4;  //speed of the player object
    private Vector3 target;   //mouse position (target destination)
    private bool isMoving = false;  //boolean determining whether the player object is moving or not
    public Rigidbody2D rb;

    public Text interTalk;

    void Start()
    {
        anim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))  //checks for mouse input
        {
            TargetPosition();
        }

        if(isMoving) //
        {
            Move();
        }

    }

    void TargetPosition()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z; //transforms player across the z axis

        isMoving = true;
    }

    void Move() //function to move player object
    {
        //command to move the player object
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        
            AnimateMovement(target);
        

        if (transform.position == target)
        {
            isMoving = false; //once the player object reaches the destination, it stops moving
            anim1.SetLayerWeight(1, 0);
        }
        
    }

    public void AnimateMovement (Vector3 direction)
    {
        anim1.SetLayerWeight(1, 1);

        //sets the parameters in the animator
        anim1.SetFloat("x", direction.x);
        anim1.SetFloat("y", direction.y);
    }
}


