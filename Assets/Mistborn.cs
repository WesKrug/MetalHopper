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
        l = gameObject.AddComponent<LineRenderer>();
        l.material = mat;
    }

    bool isPush = false;
    public float AllomanticConstant = 1.1f;
    // Update is called once per frame
    LineRenderer l;

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
                 cc.allomanticVar = new Vector2(cc.transform.position.x * AllomanticConstant, cc.transform.position.y * AllomanticConstant) * (isPush ? -1 : 1);
             }
             else
             {
                 cc.allomanticVar = Vector2.zero;
             }
        }

        if (cc.allomanticVar != Vector2.zero) 
        {        
            List<Vector3> pos = new List<Vector3>();
            l.startColor = Color.blue;
            l.endColor = Color.blue;
            pos.Add(new Vector3(cc.r2d.position.x, cc.r2d.position.y, 10));
            pos.Add(new Vector3(TargetAnchor.position.x, TargetAnchor.position.y, 10));
            l.startWidth = .1f;
            l.endWidth = .1f;
            l.SetPositions(pos.ToArray());
            
            l.useWorldSpace = true;
        }
        else {
            l.useWorldSpace = false;
        }
    }

    public float lastTapTime = 0f;
    public float tapSpeed = 0.5f; //in seconds
    public Material mat;
    Vector2 startVertex;
}
