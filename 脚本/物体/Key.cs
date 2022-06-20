using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool haveKey;
    public Rigidbody2D key;

    private void Awake()
    {
        haveKey = false;
        key = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc != null)
        {
            haveKey = true;
            Destroy(this.gameObject );
            
        }
    }
}
