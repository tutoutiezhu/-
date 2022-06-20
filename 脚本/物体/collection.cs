using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc != null)
        {
            if (pc.Mycurrenthealth < pc.Mymaxhealth)
            {
                pc.Changehealth(1);
                Destroy(this.gameObject);
            }
        }
    }
}

