using System.Collections;
using UnityEngine;
public class Dash : MonoBehaviour
{
    private Movement2D move;
    bool roll = false;
    public int cooldowntime = 3;
    [SerializeField] float boost = 30f;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement2D>();
        //using move. will now allow us to call objects and other data types from Movement2D

    }
    // Update is called once per frame
    void Update()
    {
        //detects if the right mouse button has been pressed down
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("rightclick");
            //checks if roll is currently false
            if (!roll)
            {
                Debug.Log("Spacebar was pressed!");
                roll = true;
                Dodge();
                //if roll is false then set to true and activate Dodge method

            }
        }
    }
    /// <summary>
    /// This method sends the boost float to move the player faster
    /// </summary>
    void Dodge()
    {
        //Dodger is a method that accepts a float
        move.Dodger(boost);
        StartCoroutine(CoolDown()); //coroutine, A special method that can pause and resume execution

        //doesn't block the main thread — they   let other code keep running
    }

    /// <summary>
    /// This method is reset moveSpeed and set roll to false after timers  elap

    /// this returns the player back to normal speed and allows them to   dodge again.

    /// </summary>
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.1f); //waits .1 of a second  before continueing, this gives just enough
        //time for the boost to occur but short enough to reset player speed before it can be abused

        float sD = boost - (boost * 2); //allows us to subtract our added  boost without actually altering the boost float.

        move.Dodger(sD);
        Debug.Log("coroutine started");
        yield return new WaitForSeconds(cooldowntime); //waits for x seconds  before resetting roll to false allowing
                                                       //to dodge again. x == to  coolDownTime integer

        roll = false;
    }
}