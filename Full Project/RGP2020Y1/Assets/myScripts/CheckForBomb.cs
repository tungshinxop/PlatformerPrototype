using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForBomb : MonoBehaviour
{
    public Animator feedBackAnimation;//Get instruction animator component

    private Inventory inventory;//Reference to the inventory

    public GameObject crates;

    [Header("Custom Trigger")]
    public Transform triggerPos;
    public float w, h;
    public LayerMask whatIsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Game Manager").GetComponent<Inventory>();
    }

    private void Update()
    {

        CustomTrigger();
        if (inventory.wasCratesDestroyed == true)
        {
            crates.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }


    void CustomTrigger()
    {
        bool isInRange = Physics2D.OverlapBox(triggerPos.position, new Vector2(w, h), 0, whatIsPlayer);

        if (isInRange == true)
        {
            //Show press E instruction
            feedBackAnimation.SetBool("isInRange", true);
            feedBackAnimation.SetBool("isOutsideRange", false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inventory.isBombInventory)
                {
                    inventory.wasCratesDestroyed = true;
                    Destroy(this.gameObject);
                    Destroy(crates.gameObject);
                }
            }
        }
        else
        {
            //Disable keyboard instruction
            feedBackAnimation.SetBool("isInRange", false);
            feedBackAnimation.SetBool("isOutsideRange", true);
        }
    }


    //Draw custom trigger
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(triggerPos.position, new Vector2(w, h));
    }
}
