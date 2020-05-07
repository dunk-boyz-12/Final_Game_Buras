using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // LateUpdate is called once per frame, LAST
    void LateUpdate()
    {
        Vector3 currPosition = transform.position; //get current position
        //set position axis = to player axis
        currPosition.x = Player.position.x;
        currPosition.y = Player.position.y;
        //set position back
        transform.position = currPosition;
    }
}
