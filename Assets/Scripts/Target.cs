using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    int health = 100;
    bool alreadyJumped = false;
    // Start is called before the first frame update
    public void Jump()
    {
        if(!alreadyJumped)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000f);
            alreadyJumped = true;
        }
            
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        Die();
    }

    private void Die()
    {
        if(health<=0)
        Destroy(gameObject);
    }
}
