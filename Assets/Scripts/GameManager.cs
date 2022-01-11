using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : Singleton<GameManager>
{
    public GameObject leftHeel;
    public GameObject RightHeel;
    public GameObject leftHeelClone;
    public GameObject leftParent;
    public GameObject RightHeelClone;
    public GameObject RightParent;

    GameObject gmDestroy;
    GameObject gmDestroyRight;

    GameObject leftChild;
    GameObject rightChild;


    public Animator anim;
    public bool Obtacle;
    public bool Once = true;
    public bool isGameActive = false;


    public float moveheelDown = 0;


    public List<GameObject> Leftheels = new List<GameObject>();
    public List<GameObject> Rightheels = new List<GameObject>();

    public Canvas StartCanvas;
    public Canvas RestartCanvas;
    public bool startOnce = true;
    public TextMeshProUGUI DimondText;
    public TextMeshProUGUI KeyText;


    public int DimondCount =0;
    public int KeyCount = 0;



   
    private void Awake()
    {
        Once = true;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && startOnce)
        {
            StartCanvas.gameObject.SetActive(false);
            isGameActive = true;
            anim.SetBool("ıdle", true);
            startOnce = false;
        }

        


    }

    public void AddHeel()
    {
        if(Leftheels.Count == 1)
        {
            leftHeelClone = Leftheels[0];
        }
        else
        {
            leftHeelClone = Leftheels[Leftheels.Count - (Leftheels.Count - 1)];
        }


        Vector3 leftClonePositon = new Vector3( leftHeelClone.transform.localPosition.x , leftHeelClone.transform.localPosition.y , - moveheelDown);
        
        GameObject gm  = Instantiate(leftHeel , leftClonePositon, leftHeelClone.transform.rotation);


        Clone(gm, leftClonePositon, leftParent);
        
        
        leftChild = gm.transform.GetChild(0).gameObject;
        leftChild.tag = "Untagged";
        Leftheels.Add(gm);




        if (Rightheels.Count == 1)
        {
            RightHeelClone = Rightheels[0];
        }
        else
        {
            RightHeelClone = Rightheels[Rightheels.Count - (Rightheels.Count - 1)];
        }


        Vector3 ClonePositon = new Vector3(RightHeelClone.transform.localPosition.x, RightHeelClone.transform.localPosition.y, -moveheelDown);

        GameObject gm1 = Instantiate(RightHeel, ClonePositon, RightHeelClone.transform.rotation);

        Clone(gm1, ClonePositon, RightParent);


        rightChild = gm.transform.GetChild(0).gameObject;
        rightChild.tag = "Untagged";
        Rightheels.Add(gm1);


    }

    public void Clone(GameObject gm , Vector3 ClonePositon , GameObject Parent)
    {
        gm.transform.parent = Parent.transform;
        gm.transform.localScale = Vector3.one;
        gm.transform.localPosition = ClonePositon;
        gm.transform.gameObject.tag = "Untagged";

    }


    public void RemoveHeel()
    {
        if (Leftheels.Count == 1)
        {
            gmDestroy = Leftheels[0];
        }

        else
        gmDestroy = Leftheels[Leftheels.Count-1];

        Leftheels.Remove(gmDestroy);
        Destroy(gmDestroy);

        if (Rightheels.Count == 1)
        {
            gmDestroyRight = Rightheels[0];
        }

        else
        gmDestroyRight = Rightheels[Rightheels.Count-1];


       
        Rightheels.Remove(gmDestroyRight);
        Destroy(gmDestroyRight);

        Debug.Log("topuk azal");


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
