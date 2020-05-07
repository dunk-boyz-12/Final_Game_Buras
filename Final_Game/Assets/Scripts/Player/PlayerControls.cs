using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    //serialize to see in unity editor
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Rigidbody2D player;
    private Vector2 movement;
    [SerializeField] private Animator animator;


    void Awake()
    {
        player = GetComponent<Rigidbody2D>(); //get player object
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        animator.SetFloat("playerSpeed", Math.Abs(movement.x)); //change animation on change in player move speed
    }
    
    void FixedUpdate() //called before every physics frame
    {
        CharacterMove(movement); //pass in current position
    }

    void CharacterMove(Vector2 dir)
    {
        player.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.fixedDeltaTime)); //fixedDeltaTime is time since func was last called

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 0); //flip for left
            //player.GetComponent<>
        };
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector2(0, 180); //no flip for right
        };
    }

    void Open()
    {

    }

    void CollectItems()
    {

    }
}
