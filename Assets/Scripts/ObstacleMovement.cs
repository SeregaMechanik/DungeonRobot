using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private int RemAmountOfMove = 0;
    private char direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RemAmountOfMove == 0)
        {
            System.Random random = new System.Random();
            int randDir = random.Next(0, 2);
            if (randDir == 0)
            {
                direction = 'L';
            }
            else
            {
                direction = 'R';
            }
            RemAmountOfMove = 1000;
        }

        Vector3 movement;
        if (direction == 'R')
        {
            movement = Vector3.right;
        }
        else
        {
            movement = Vector3.left;
        }
        float timeSinceLastFrame = Time.deltaTime;
        Vector3 translation = movement * timeSinceLastFrame;
        transform.Translate(translation);
        RemAmountOfMove--;
    }
}
