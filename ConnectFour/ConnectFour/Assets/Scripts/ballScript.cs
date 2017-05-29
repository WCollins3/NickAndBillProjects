using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

    public float speed;
    public GameObject ball;
    private Rigidbody rb;
    private Vector3 spawn;
    public bool move;
    public static bool fin;
    private int[] columns;

    // Use this for initialization
    void Start () {
        spawn = transform.position;
        move = false;
        fin = false;
        rb = GetComponent<Rigidbody>();
        columns = new int[7] { -30, -20, -10, 0, 10, 20, 30};

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z - 1);
        }
        if (move == false && fin == false)
        {
            float down = Input.GetAxis("Vertical");
            if (down < 0.0)
            {
                move = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                float currLoc = ball.transform.position.x;
                int index = -1;

                for (int i = 0; i < columns.Length; i++)
                {
                    if (currLoc == columns[i])
                    {
                       index = i;
                    }
                }

                index = index + 1;
                try
                {
                    ball.transform.position = new Vector3(columns[index], ball.transform.position.y, ball.transform.position.z);
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    // error
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                float currLoc = ball.transform.position.x;
                int index = -1;

                for (int i = 0; i < columns.Length; i++)
                {
                    if (currLoc == columns[i])
                    {
                        index = i;

                    }
                }

                index = index - 1;

                try
                {
                    ball.transform.position = new Vector3(columns[index], ball.transform.position.y, ball.transform.position.z);
                }
                catch(System.IndexOutOfRangeException ex)
                {
                    // error
                }
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stop"))
        {
            move = false;
            fin = true;
            enabled = false;
        }
    }

}
