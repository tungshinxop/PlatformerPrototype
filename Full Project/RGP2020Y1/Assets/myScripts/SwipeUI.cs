using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This script in game manager in charge of Swipe UI behaviour
/// </summary>
/// 

/////////////////////////////////// NOTE TO SELF ///////////////////////////////////
//                            Arithmetic Progression
//  u(n) is an arithmetic progression sequence if u(n+1) = u(n) + d with n is a whole number, d is a constant known as the difference/distance between 2 numbers
//  u(n) = u(1) + (n-1)*d (n>=2)
//  d = (u(n) - u(1))/(n-1)
//  u(k) = ( u(k-1) + u(k+1) ) / 2
//  Sum(n) = n * ( u(1) + u(n) ) /2 
//  Sum(n) = n*( 2*u(1) + (n-1)*d ) / 2 
//                            Arithmetic Progression
/////////////////////////////////// NOTE TO SELF ///////////////////////////////////
public class SwipeUI : MonoBehaviour
{
    public GameObject scrollbar; //Reference to scrollbar ui
    private float scrollPos = 0;//Postion of scrollbar
    float distance; //Distance between to child objects in the array

    [SerializeField] float[] theNumberOfValues;//Array

    private void Awake()
    {
        //This array made up of components which are the transform of child objects
        theNumberOfValues = new float[transform.childCount];
    }

    void Update()
    {
        //Calculate the distance between the children (scale from 0 to 1 to match the position corresponding to the scrollbar pos)
        //Example: there are 11 child objects ---> the space between each child object is 0.1f ( 0 , 0.1, 0.2, ..., 1)
        distance = 1f / (theNumberOfValues.Length - 1f); //  d = (u(n) - u(1))/(n-1)

        //Apply the above distance to the actual transform of child objects
        for (int i = 0; i < theNumberOfValues.Length; i++)
        {
            theNumberOfValues[i] = distance * i ;
        }

        //Get the position of the child objects (translated to scrollbar pos) when the mouse is held down
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
            Debug.Log("Scrollbar position: " + scrollPos);
        }


        else
        {
            //When release mouse, lerp the child nearest to center to the center of the canvas
            for (int i = 0; i < theNumberOfValues.Length; i++)
            {
                //Focus on the middle object between two objects
                //u(k) = ( u(k-1) + u(k+1) ) / 2

                //Example for the 11 child objects
                //The 2nd object will have the pos of 0.1 ---> Translate if condition: 0.1 - (0.1/2) < roughly 0.1 < 0.1 + (0.1/2) 
                // = 0.05 < ~0.1 < 0.15 (this only work provided that i is checked to satisfy the formula)
                //similar pattern also apply --> 0.1 < ~0.2 (3rd child object) < 0.3 ---> Lerp to focus on the third child object
                if (scrollPos < theNumberOfValues[i] + (distance / 2) && scrollPos > theNumberOfValues[i] - (distance / 2))
                {
                    //Lerp from the postion where the mouse is release to the child postion satisfy the if condition
                    //I find interpolation value between 0.1 ~ 0.15 the most suitable one so that lerp actions almost immediately
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, theNumberOfValues[i], 0.1f);
                }
            }
        }


        for (int i = 0; i < theNumberOfValues.Length; i++)
        {
            //Check for the focused child object using the same if condition as above
            if (scrollPos < theNumberOfValues[i] + (distance / 2) && scrollPos > theNumberOfValues[i] - (distance / 2))
            {
                //Make the focused child object slightly bigger
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                for (int j = 0; j < theNumberOfValues.Length; j++)
                {
                    if (j != i)
                    {
                        //Make the non focused child object slightly smaller
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }

    }
}
