using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script in tree
/// </summary>
public class QuickTimeTree : MonoBehaviour
{
    public GameObject[] treeBranches;//Storing the tree branches

    public bool isEven = true;
    //public bool isOdd = false;

    public float timeBTWTransition;
    public float startTimeBTWTransition;
    void Start()
    {
        timeBTWTransition = startTimeBTWTransition;
    }

    void Update()
    {
        EvenOn();

        if (Input.GetKeyDown(KeyCode.T))
        {
            isEven = true;
            //isOdd = false;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            isEven = false;
            //isOdd = true;
        }


        if (isEven)//Turn on branches in even position in the array
        {
            for (int i = 0; i < treeBranches.Length; i++)
            {
                if(i % 2 == 0)//Check if i value can be divisible by 2-->Even number
                {
                    treeBranches[i].SetActive(true);
                }
                else
                {
                    treeBranches[i].SetActive(false);
                }
            }
        }
        else if (!isEven)//Turn on branches in odd position in the array
        {
            for (int i = 0; i < treeBranches.Length; i++)
            {
                if (i % 2 != 0)//Check if i value cannot be divisible by 2-->Odd number
                {
                    treeBranches[i].SetActive(true);
                }
                else
                {
                    treeBranches[i].SetActive(false);
                }
            }
        }
    }

    private bool EvenOn()
    {
        if (isEven)
        {
            if(timeBTWTransition <= 0)
            {
                timeBTWTransition = startTimeBTWTransition;
                return isEven = false;
            }
            else
            {
                timeBTWTransition -= Time.deltaTime;
                return isEven = true;
            }
        }
        else
        {
            if (timeBTWTransition <= 0)
            {
                timeBTWTransition = startTimeBTWTransition;
                return isEven = true;
            }
            else
            {
                timeBTWTransition -= Time.deltaTime;
                return isEven = false;  
            }
        }
    }
}
    
