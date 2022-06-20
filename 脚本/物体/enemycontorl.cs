using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontorl : MonoBehaviour
{

    public float speed = 3;
    private Rigidbody2D enemy;
    public bool isVertical;//�Ƿ��ڴ�ֱ�������ƶ�
    public bool isHorizontal;//�Ƿ���ˮƽ�������ƶ�
    private Vector2 moveDirection;//�ƶ�����
    public float changeDirectionTime = 2f ;//�ı䷽���ʱ��
    private float changeTimer;//�ı䷽���ʱ���ʱ��
    private Animator anim;
    public  bool isAttacked;//�ж�enemy״̬ false����ʧ true�����
    public  int attackTime = 0 ;//��¼���˴��� 3������ʧ




    void Start()
    {
        enemy = GetComponent<Rigidbody2D >();
        anim = GetComponent<Animator>();
        //����ѡ�� ��ֱ���� ˮƽ�ͳ���
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


    //enemy������ҵ���ײ�����˺�
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
