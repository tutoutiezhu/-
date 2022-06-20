using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackcontrol : MonoBehaviour
{

    public Animator anim;
    private Rigidbody2D rbody;//获取攻击的刚体
    // Start is called before the first frame update
    void Awake()
    {
        
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,2f);

    }

    //攻击移动
    public void Move(Vector2 moveDirection,float moveForce) {

        rbody.AddForce(moveDirection * moveForce);
            
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        enemycontorl ec = other.gameObject.GetComponent<enemycontorl>();
        if (ec != null) {
            ec.attackTime++;
       
            {
                if (ec.attackTime >= 3)
                {
                    ec.isAttacked = true;
                    ec.Attacked();
                }
            
            }
            
            Debug.Log("击中敌人");

            
        }

        
        Destroy(this.gameObject);
    }

}
