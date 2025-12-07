using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud01Script : MonoBehaviour
{

public float speed = 0.5f;   // how fast the cloud moves
    public float resetX = -12f;  // left edge of the screen
    public float startX = 12f;   // right edge of the screen

    void Update()
    {

        transform.position += Vector3.right * speed * Time.unscaledDeltaTime;

        if (transform.position.x < resetX)
        {
              transform.position = new Vector3(startX, transform.position.y, transform.position.z);

        }
    }

}
