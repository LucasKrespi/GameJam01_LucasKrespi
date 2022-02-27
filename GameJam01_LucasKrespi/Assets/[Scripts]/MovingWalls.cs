using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    public bool move = false;
    public float speed;
    public Transform goalPoint;

    private Vector3 starterPosition;
    // Start is called before the first frame update
    void Start()
    {
        starterPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = starterPosition;
        }
    }

    public void ResetWall()
    {
        transform.position = starterPosition;
    }
}
