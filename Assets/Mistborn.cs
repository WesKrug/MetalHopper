using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mistborn : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform TargetAnchor;
    public CharacterController2D cc;
    
    void Start()
    {
        
    }

    bool isPush = false;
    public float AllomanticConstant = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if((Time.time - lastTapTime) < tapSpeed)
            {
                isPush = true;
            }
            else 
            {
                isPush = false;
            }
            lastTapTime = Time.time;
        }
        
        if ((Time.time - lastTapTime) > tapSpeed ) 
        {
            if (Input.GetKey(KeyCode.Keypad3))
             {
                 cc.allomanticVar = AllomanticConstant * (isPush ? -1 : 1);
             }
             else 
             {
                 cc.allomanticVar = 0f;
             }
        }
    }

    public float lastTapTime = 0f;
    public float tapSpeed = 0.5f; //in seconds
}
