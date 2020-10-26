using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Waypoints[] navPoints;
    private Transform target;
    private Vector3 direction;
    public float amplify = 1;
    private int index = 0;
    private bool move = true;

     
    // enemy stats
    private int health = 4;

    public Text enemyHealthText;
    // Start is called before the first frame update
    void Start()
    {
        //Place our enemy at the start point
        transform.position = navPoints[index].transform.position;
        NextWaypoint();
        
        //Move towards the next waypoint
        //Retarget to the following waypoint when we reach our current waypoint
        //Repeat through all of the waypoints until you reach the end
    }

  // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = "Enemy Health: " + (health + 1);
        if (move)
        {
            transform.Translate(direction.normalized * Time.deltaTime * amplify);

            if ((transform.position - target.position).magnitude < .1f)
            { 
                NextWaypoint();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (health > 0)
                {
                    health--;
                    Debug.Log("Health was decreased");
                }
                else
                {
                    health--; 
                    Destroy(gameObject);
                    LevelStats.coins += 10;
                }
            }
            
        }
    }

    private void NextWaypoint()
    {
        if (index < navPoints.Length - 1)
        {
            index += 1;
            target = navPoints[index].transform;
            direction = target.position - transform.position;
        }
        else
        {
            move = false;
        }
    }
}
