using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseStarter : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 100 * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coins.SetActive(true);
            foreach(var w in walls)
            {
                w.GetComponent<MovingWalls>().move = true;
            }
            gameObject.SetActive(false);
        }
    }

    public void ResetWalls()
    {
        foreach (var w in walls)
        {
            w.GetComponent<MovingWalls>().ResetWall();
        }
    }
}
