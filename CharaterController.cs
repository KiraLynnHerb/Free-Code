/******
* 
*Author: Kira Herb
*Date of creation: 1/6/19
*Date of last update: 1/6/19
*Last update: Added movement for character movement 
* 
******/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterController : MonoBehaviour
{
    /***
    *This is a list of variable that will be used in the script
    ****/

    public Animation Anim;

    public Rigidbody2D rb2d;

    public GameObject menu;

    public GameObject battleCam;

    public GameObject trainer;

    public float speed = 0;

    public float up = 0;

    public bool inactive = false;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        //This saves the rigidbody that is attached to the game object so it can be multiplated 

    }

    void FixedUpdate()
    {
        /******
         *This is a group of if statements that will allow the player to add movement to the player 
         * This does not allow for diagonal movement
         * This will check if the game is 'paused' and will not movement if it is paused
         ********/
        if (Input.GetButtonDown("Pause") )
        {

            inactive = !inactive;

        }

        if (!inactive)
        {
            menu.SetActive(false);

            if (Input.GetButton("Horizontal"))
            {
                up = 0;

                if (Input.GetAxis("Horizontal") > 0)
                {

                    speed = -10;

                    rb2d.velocity = new Vector2(0, 0);

                }

                if (Input.GetAxis("Horizontal") < 0)
                {

                    speed = 10;

                    rb2d.velocity = new Vector2(0, 0);

                }

            }

            if (Input.GetButton("Vertical"))
            {
                speed = 0;

                if (Input.GetAxis("Vertical") > 0)
                {

                    up = -10;

                    rb2d.velocity = new Vector2(0, 0);

                }

                if (Input.GetAxis("Vertical") < 0)
                {

                    up = 10;

                    rb2d.velocity = new Vector2(0, 0);

                }

            }

            rb2d.velocity = new Vector2(speed, up);

            speed = 0;

            up = 0;

        }

        if (inactive && !battleCam.activeSelf)
        {

            menu.SetActive(true);

            rb2d.velocity = new Vector2(0, 0);

        }

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        trainer.SetActive(false);

        battleCam.SetActive(true);

        inactive = true;

    }


}
