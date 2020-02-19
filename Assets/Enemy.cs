using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public Animator animator;

    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;

    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        //play animation

        if (currentHealth <= 0)
        {
            // die animation
            animator.SetBool("isDead", true);
            //diable enmey
            GetComponent<BoxCollider2D> ().enabled = false;
            this.enabled = false;
           
            
            

        }
    }


}
