using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{

    //Reference to waypoints
    public List<Transform> points;
    //Integer for the next point index
    public int nextID = 0;
    //The value of that applies to ID for changing (incrise 1 or decrese 1)
    private int idChangeValue = 1;

    public float speed = 2;

    private void Reset()
    {

        Init();
        
    }

    void Init()
    {
        //Make box collider trigger
        //GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root object
        GameObject root = new GameObject(name + "Root");

        //Reset position of root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Create waypoints object
        GameObject waypoints = new GameObject("Waypoints");

        //Reset waypoints to root
        //Make waypoints objectchild of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Create two points (gameobject) and reset their position to waypoints objects
        //Make thE points children of waypoint object
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into point's direction
        if(goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime);
        //Check the distance between enemy and goal point to trigger next point
        if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line (make the change -1)
            if(nextID == points.Count - 1)
            {
                idChangeValue = -1;
            }
            //Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
            {
                idChangeValue = 1;
            }
            
            //Apply the change on the nextID
            nextID += idChangeValue;
        }

    }

}
