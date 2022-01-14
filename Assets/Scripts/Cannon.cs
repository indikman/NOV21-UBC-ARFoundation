using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float turnSpeed = 50;
    public float shootForce = 40;

    public Transform spawnPoint;
    public GameObject cannonBallPrefab;

    private GameObject currentRobot;

    void Start()
    {
        InvokeRepeating("Shoot", 3f, 1f);
    }


    void Update()
    {
        // find the robot
        if(currentRobot == null)
        {
            
            currentRobot = GetRobot();

        }
        

        // if there is a robot, shoot!
        if(currentRobot)
        {
            RotateTowardsTheRobot();
        }
    }

    private GameObject GetRobot()
    {
        RobotMovement robot = FindObjectOfType<RobotMovement>();

        if (robot)
        {
            return robot.gameObject;
        }

        return default;
    }

    private void RotateTowardsTheRobot()
    {
        Vector3 targetDirection = currentRobot.transform.position - transform.position;
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0);

        direction = new Vector3(direction.x, 0, direction.z);

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Shoot()
    {
        if (currentRobot)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            cannonBall.GetComponent<Rigidbody>().AddForce(shootForce * spawnPoint.forward);

            Destroy(cannonBall, 2); // Destroys the cannon ball after 2 seconds
        }
    }

}
