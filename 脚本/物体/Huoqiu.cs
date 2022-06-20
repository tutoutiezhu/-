using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huoqiu : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D enemy;
    public bool isVertical;//是否在垂直方向上移动
    public bool isHorizontal;//是否在水平方向上移动
    private Vector2 moveDirection;//移动方向
    private Animator anim;
   





    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //条件选择 垂直朝上 水平就朝右
        moveDirection = isVertical ? Vector2.up : Vector2.left;
        Destroy(this.gameObject, 2f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        Vector2 position = enemy.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        enemy.MovePosition(position);

    }


    //enemy对于玩家的碰撞检测和伤害
    private void OnCollisionEnter2D(Collision2D other)
    {
        playercontrol pc = other.gameObject.GetComponent<playercontrol>();
        if (pc != null)
        {
            pc.Changehealth(-1);
            Destroy(this.gameObject);
        }


    }


    
}
