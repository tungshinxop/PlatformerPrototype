using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public Transform thisPos;//Reference to the  'trigger' postion
    public float width, height;//The value to create custom box trigger
    public LayerMask whatIsPlayer;//The layermask refer to player to return 'bool' true

    public string sceneToLoad;//The string to load
    public Vector2 playerPos;//Player position in the loaded scene
    public VectorValue positionInMemory;//Reference to the VectorValue script

    private void Start()
    {
        thisPos = this.transform;//Set doorPos to the position of the door trigger
    }
    private void Update()
    {
        //A bool return true if a game object tagged player is in range of a custom box trigger with the position of doorPos nad width,height as width and height
        bool playerDetected = Physics2D.OverlapBox(thisPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if (playerDetected == true)
        {
            positionInMemory.initialValue = playerPos;//Store the postion at which player pressed E 
            SceneManager.LoadScene(sceneToLoad);//Load the scene accordingly
        }
    }

    private void OnDrawGizmos() //Draw gizmo
    {
        Gizmos.color = Color.red; //Set gizmo color to blue
        Gizmos.DrawWireCube(thisPos.position, new Vector2(width, height)); //Draw box gizmo at doorPos postion with the width and height as stated
    }
}
