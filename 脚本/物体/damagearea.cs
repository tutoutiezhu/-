using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagearea : MonoBehaviour//ÉËº¦ÏÝÚå
{
   
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc != null) {
            pc.Changehealth(-1);
            Destroy(this.gameObject);

        }
        
    }
}
