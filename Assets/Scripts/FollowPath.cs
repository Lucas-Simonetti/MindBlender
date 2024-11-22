using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : MonoBehaviour
{

    [SerializeField] Transform[] Points;

    [SerializeField] private float moveSpeed;

    private int pointsIndex;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points. Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            animator.SetInteger("Umbra", 1);

            if(transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex++; 
            }
        }
        else
        {
            animator.SetInteger("Umbra", 0);
        }
    }
}
