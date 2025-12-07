using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5; 
    public float deadZone = -45;
    private LogicScript logic;
    void Start()
    {
        // Grab reference to LogicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
    if (!logic.isGameOver)
        {
        // this ensures the mulitplications happens the same no matter the frame rate. For more: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Time-deltaTime.html
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;  
        }
    
      if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
