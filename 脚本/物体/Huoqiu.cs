using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huoqiu : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D enemy;
    public bool isVertical;//�Ƿ��ڴ�ֱ�������ƶ�
    public bool isHorizontal;//�Ƿ���ˮƽ�������ƶ�
    private Vector2 moveDirection;//�ƶ�����
    private Animator anim;
   





    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //����ѡ�� ��ֱ���� ˮƽ�ͳ���
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


    //enemy������ҵ���ײ�����˺�
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
