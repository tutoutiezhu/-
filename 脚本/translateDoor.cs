using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateDoor : MonoBehaviour
{
    //����ȥ��������
    public Transform goToPos;
    //������Ϸ��ɫ������
    private Transform playerPos;
    public bool isButton;

    void Start()
    {
        //��ȡ��Ϸ��ɫ������
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        isButton = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isButton == true) {
            
            playerPos.transform.position = goToPos.transform.position;

        }
    }
    //�����ײ�ж�
    private void OnTriggerEnter2D(Collider2D other)
    {
        //������ײ���¼��̵�E��
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //����Ϸ��ɫ��λ���޸�Ϊȥ����λ��
        //    playerPos.transform.position = goToPos.transform.position;
        // }
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc != null)
        {
            isButton = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc!=null) {
            isButton = false;
        }
    }


}
