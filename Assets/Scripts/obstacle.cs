using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class obstacle : MonoBehaviour
{
    public GameObject Player;
    public bool once = true;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("heel") && once)
        {
            if(GameManager.Instance.Leftheels.Count == 0)
            {
                GameManager.Instance.isGameActive = false;
                Debug.Log("stop");
               Player.transform.position -= new Vector3(0,0,0.8f);
                GameManager.Instance.anim.SetBool("fall", true);
                Player.transform.position -= new Vector3(0, 0.4f, 0);
                GameManager.Instance.RestartCanvas.gameObject.SetActive(true);
                Debug.Log("düş");


            }

            else
            {
                GameManager.Instance.Obtacle = true;
                GameManager.Instance.RemoveHeel();
                GameManager.Instance.moveheelDown -= 0.3f;
                Player.transform.position += new Vector3(0, -0.2f, 0);
                once = false;
            }
            
        }
    }
}
