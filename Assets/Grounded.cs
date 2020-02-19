using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    // GameObject Player;
    // GameObject gameObject;
    GameObject Player;
    //  = gameObject.transform.parent.gameObject;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENtered");
        if (collision.collider.tag == "Ground")

        {
            Debug.Log("ENtered2");


            Player.GetComponent<CharacterMove>().isGrounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");

        if (collision.collider.tag == "Ground")
        {
            Debug.Log("Exite2");

            Player.GetComponent<CharacterMove>().isGrounded = false;
        }

    }
}
