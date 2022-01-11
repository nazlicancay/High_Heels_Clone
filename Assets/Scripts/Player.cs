using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotateMultiplier;
    public float swipeSpeed;
    public float maxLeftX;
    public float maxRightX;

    public float speed;

    private Quaternion targetRotation;
    private bool turnOnce = true;

    [SerializeField] private Animation animation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameActive)
        {
            if (transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed);
            }

            if (GameManager.Instance.isGameActive)
            {
                transform.position += transform.forward * Time.deltaTime;
            }
        }
       







    }

    public void RotateCharacter(Vector2 position)
    {
        position = position.normalized;
        Quaternion rotation = Quaternion.AngleAxis(position.x * rotateMultiplier, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2);
    }


    public void InputUpdate(Vector2 delta)
    {
        if (GameManager.Instance.isGameActive)
        {
            Vector3 newPos = transform.position + new Vector3(delta.x * swipeSpeed, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, maxRightX, maxLeftX);
            transform.position = newPos;

        }

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("heel"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddHeel();
            other.gameObject.tag = "Untagged";

            transform.position += new Vector3(0f, 0.2f, 0f);
            GameManager.Instance.moveheelDown += 0.3f;
        }

        

        if (other.CompareTag("lastWalk"))
        {
           //s speed = 0;
            GameManager.Instance.isGameActive = false;
            //GameManager.Instance.anim.SetBool("finishAnim", true);
            animation.Play("finishAnim");


        }

        if (other.CompareTag("finish"))
        {
            GameManager.Instance.anim.SetBool("lastWalk", true);

            
        }

        if (other.CompareTag("key"))
            {

            GameManager.Instance.KeyCount += 1;
            GameManager.Instance.KeyText.text = "Key " +GameManager.Instance.KeyCount.ToString();
            Destroy(other.gameObject);

        }

        if (other.CompareTag("dimond"))
        {
            GameManager.Instance.DimondCount += 1;
            GameManager.Instance.DimondText.text = "Dimond " + GameManager.Instance.DimondCount.ToString();
            Destroy(other.gameObject);



        }


    }
}
