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
    public Animator anim;//额外攻击次数
    public int totalAttacktime = 5;//总共的攻击次数
    public int currentAttacktime;
    public bool noBullet=false;//表示没有子弹
    private float reloadTimer;//换子弹计时器
    public Text bulletNum;
    
    private int maxhealth = 5;//最大生命值
    private int currenthealth = 5;//当前生命值
    public Text healthNum; //用于标记当前血量
    public int Mymaxhealth { get { return maxhealth; } }
    public int Mycurrenthealth { get { return currenthealth; } }

    private float invincibleTime = 2f;//伤害触发后的短暂不受伤害的时间
    private float invincibleTimer;//上面的计时器
    private bool isInvincible;

    private Vector2 facedirection = new Vector2(1, 0);//角色方向默认朝右
    public GameObject attackPrefab;//攻击的物体

    //=====玩家音效
    public AudioClip shootClip;
    public AudioClip hitClip;
    //暂停
    public Mainmenu mn;

    void Start()
    {
        invincibleTimer = 0;
        reloadTimer = 2 ;
        playerbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (mn.isShow == false)//若不处于暂停状态则可动，否则不动
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
        //射击
       

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
        reloadTimer -= Time.deltaTime;//间隔2秒换子弹


    }

    void Movement()
    {

        /*float horizontalmove = Input.GetAxisRaw("Horizontal");
        float verticalmove = Input.GetAxisRaw("Vertical");
        Vector2 moveVector = new Vector2(horizontalmove, verticalmove);

        //运动方式的转换
        if (moveVector.x != 0 || moveVector.y != 0)
        {

            facedirection = moveVector;
        }
        anim.SetFloat("horizontal", facedirection.x);
        anim.SetFloat("vertical", facedirection.y);
        anim.SetFloat("playerspeed", moveVector.magnitude);*/

        //角色移动
        /*Vector2 position = playerbody.position;
        position.x += horizontalmove * Time.deltaTime * speed;
        position.y += verticalmove * Time.deltaTime * speed;
        playerbody.MovePosition(position);*/
        /*if (horizontalmove != 0 || verticalmove != 0)
        {
            transform.Translate(horizontalmove * speed * Time.deltaTime, verticalmove * speed * Time.deltaTime, 0);
        }*/

        //-----生命值计时----
        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime < 0) isInvincible = false;
            //结束不受伤害的时间

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




    //改变玩家生命值
    public void Changehealth(int amount)
    {
        //受到伤害的反馈
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

        /*约束玩家的生命值 1、当前生命值变化 
         * 2、最小生命值 3、最大生命值*/
       




    }

 

    public void DeathBack() {
        
        SceneManager.LoadScene("country");
    
    }

} 