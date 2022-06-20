using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{

    public float speed;
    public Rigidbody2D playerbody;
    public float horizontalmove;
    public float verticalmove;
    public Animator anim;//���⹥������
    public int totalAttacktime = 5;//�ܹ��Ĺ�������
    public int currentAttacktime;
    public bool noBullet=false;//��ʾû���ӵ�
    private float reloadTimer;//���ӵ���ʱ��
    public Text bulletNum;
    
    private int maxhealth = 5;//�������ֵ
    private int currenthealth = 5;//��ǰ����ֵ
    public Text healthNum; //���ڱ�ǵ�ǰѪ��
    public int Mymaxhealth { get { return maxhealth; } }
    public int Mycurrenthealth { get { return currenthealth; } }

    private float invincibleTime = 2f;//�˺�������Ķ��ݲ����˺���ʱ��
    private float invincibleTimer;//����ļ�ʱ��
    private bool isInvincible;

    private Vector2 facedirection = new Vector2(1, 0);//��ɫ����Ĭ�ϳ���
    public GameObject attackPrefab;//����������

    //=====�����Ч
    public AudioClip shootClip;
    public AudioClip hitClip;
    //��ͣ
    public Mainmenu mn;

    void Start()
    {
        invincibleTimer = 0;
        reloadTimer = 2 ;
        playerbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (mn.isShow == false)//����������ͣ״̬��ɶ������򲻶�
        {
            horizontalmove = Input.GetAxisRaw("Horizontal");
            verticalmove = Input.GetAxisRaw("Vertical");
            Vector2 moveVector = new Vector2(horizontalmove, verticalmove);
            if (moveVector.x != 0 || moveVector.y != 0)
            {

                 facedirection = moveVector;
             }
            anim.SetFloat("horizontal", facedirection.x);
            anim.SetFloat("vertical", facedirection.y);
            anim.SetFloat("playerspeed", moveVector.magnitude);
        //���
       

            if (Input.GetKeyDown(KeyCode.J) && noBullet == false && totalAttacktime > 0)
            {

                totalAttacktime--;
                currentAttacktime = totalAttacktime;
                bulletNum.text = totalAttacktime.ToString();
                if (totalAttacktime <= 0)
                {

                    noBullet = true;

                }
                GameObject attackObjeckt = Instantiate(attackPrefab, playerbody.position, Quaternion.identity);
                Audiomanager.instance.AudioPlay(shootClip);
                attackcontrol bc = attackObjeckt.GetComponent<attackcontrol>();
                if (bc != null)
                {
                    bc.Move(facedirection, 400);
                 }
            }
            else if (noBullet == true)
            {
                
                    if (Input.GetKeyDown(KeyCode.R) && reloadTimer < 0)
                    {
                        noBullet = false;
                        totalAttacktime = 5;
                        reloadTimer = 2;
                        bulletNum.text = totalAttacktime.ToString();
                    
                    }

            }
        }
            
     }
    
    void FixedUpdate()
    {


        Vector2 position = playerbody.position;
        position.x += horizontalmove * Time.deltaTime * speed;
        position.y += verticalmove * Time.deltaTime * speed;
        playerbody.MovePosition(position);
        Movement();
        reloadTimer -= Time.deltaTime;//���2�뻻�ӵ�


    }

    void Movement()
    {

        /*float horizontalmove = Input.GetAxisRaw("Horizontal");
        float verticalmove = Input.GetAxisRaw("Vertical");
        Vector2 moveVector = new Vector2(horizontalmove, verticalmove);

        //�˶���ʽ��ת��
        if (moveVector.x != 0 || moveVector.y != 0)
        {

            facedirection = moveVector;
        }
        anim.SetFloat("horizontal", facedirection.x);
        anim.SetFloat("vertical", facedirection.y);
        anim.SetFloat("playerspeed", moveVector.magnitude);*/

        //��ɫ�ƶ�
        /*Vector2 position = playerbody.position;
        position.x += horizontalmove * Time.deltaTime * speed;
        position.y += verticalmove * Time.deltaTime * speed;
        playerbody.MovePosition(position);*/
        /*if (horizontalmove != 0 || verticalmove != 0)
        {
            transform.Translate(horizontalmove * speed * Time.deltaTime, verticalmove * speed * Time.deltaTime, 0);
        }*/

        //-----����ֵ��ʱ----
        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime < 0) isInvincible = false;
            //���������˺���ʱ��

        }


        /*if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject attackObjeckt = Instantiate(attackPrefab, playerbody.position, Quaternion.identity);

            attackcontrol bc = attackObjeckt.GetComponent<attackcontrol>();
            if (bc != null)
            {
                bc.Move(facedirection, 300);


            }
            

        }*/






    }




    //�ı��������ֵ
    public void Changehealth(int amount)
    {
        //�ܵ��˺��ķ���
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxhealth);
        if (currenthealth <= 0) {
            Invoke("DeathBack", 2f);
            
        }
        if (amount <=0)
        {
            Audiomanager.instance.AudioPlay(hitClip);
            if (isInvincible == true)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = invincibleTime;
            healthNum.text = currenthealth.ToString();


        }
        else healthNum.text = (currenthealth).ToString();

        /*Լ����ҵ�����ֵ 1����ǰ����ֵ�仯 
         * 2����С����ֵ 3���������ֵ*/
       




    }

 

    public void DeathBack() {
        
        SceneManager.LoadScene("country");
    
    }

} 