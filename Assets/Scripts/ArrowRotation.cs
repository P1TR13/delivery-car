using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public Transform player, destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {

        Quaternion targetRotation = new Quaternion();
        float step = 2f * Time.deltaTime;
        float deltaY = (player.transform.position.y - destination.transform.position.y);
        float deltaX = (player.transform.position.x - destination.transform.position.x);
        float distance = Mathf.Sqrt(Mathf.Pow(deltaY, 2) + Mathf.Pow(deltaX, 2));
        float betta = Mathf.Cos(deltaX / distance);
        //Debug.Log(betta);
        //Debug.Log(deltaX / distance);
        float alpha = player.rotation.y - betta;
        //Debug.Log(alpha);
        alpha *= 100;

        targetRotation = Quaternion.Euler(0, 0, alpha);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
    }
}
