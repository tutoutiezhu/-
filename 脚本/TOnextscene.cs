using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TOnextscene : MonoBehaviour
{
    public Key ky;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ky.haveKey == true)//�õ���Կ��
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ky.haveKey = false;//һ��һ��Կ��
        
        }    
    }
}
