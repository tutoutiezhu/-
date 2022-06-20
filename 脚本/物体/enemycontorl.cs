using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontorl : MonoBehaviour
{

    public float speed = 3;
    private Rigidbody2D enemy;
    public bool isVertical;//是否在垂直方向上移动
    public bool isHorizontal;//是否在水平方向上移动
    private Vector2 moveDirection;//移动方向
    public float changeDirectionTime = 2f ;//改变方向的时间
    private float changeTimer;//改变方向的时间计时器
    private Animator anim;
    public  bool isAttacked;//判断enemy状态 false则消失 true则存在
    public  int attackTime = 0 ;//记录受伤次数 3次则消失




    void Start()
    {
        enemy = GetComponent<Rigidbody2D >();
        anim = GetComponent<Animator>();
        //条件选择 垂直朝上 水平就朝右
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        changeTimer = changeDirectionTime;
        isAttacked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0) { 
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
        Vector2 position = enemy.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        enemy.MovePosition (position);

    }


    //enemy对于玩家的碰撞检测和伤害
    private void OnCollisionEnter2D(Collision2D other )
    {
        playercontrol pc = other.gameObject.GetComponent <playercontrol>();
        if (pc != null) {
            pc.Changehealth(-1);
        }


    }


    public void Attacked() {
        

        Destroy(this.gameObject);
    
    }
}
