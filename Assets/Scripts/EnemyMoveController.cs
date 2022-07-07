using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    private bool grounded;
    public LayerMask whatIsGround;

    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    public float playerSpeed;

    public Transform[] roadPath;

    private int currentPathPoint;

    public void SetPath(Transform[] path)
    {
        roadPath = path;
    }

    void Start()
    {
        currentPathPoint = 0;
    }

    void Update()
    {
        if (roadPath != null)
        {
            DetectPosition();
            DetectRotation();
        }
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }

    private void DetectRotation()
    {
        Quaternion targetRotation = new Quaternion();
        Vector3 targetPoint;
        float step = 10f * Time.deltaTime;

        targetPoint = new Vector3(roadPath[currentPathPoint].transform.position.x, transform.position.y, roadPath[currentPathPoint].transform.position.z);

        if (targetPoint != Vector3.zero)
            targetRotation = Quaternion.LookRotation(-targetPoint);
        //Debug.Log(targetRotation);
        //targetRotation = Quaternion.Euler(targetRotation.x, targetRotation.y - 90, targetRotation.z);
        //targetRotation = Quaternion.Euler(targetRotation.x, (targetRotation.y)*2, targetRotation.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
        //Debug.Log(transform.rotation);
    }

    private void DetectPosition()
    {
        float step = playerSpeed * Time.deltaTime; 

        if (transform.position != roadPath[currentPathPoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                roadPath[currentPathPoint].transform.position, step);
        }
        else
        {
            if (currentPathPoint < roadPath.Length - 1)
            {
                currentPathPoint++;
            }
            else
            {
                currentPathPoint = 0;
            }
        }
    }

}
