using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    float randX, randZ;

    // Start is called before the first frame update
    void Start()
    {
        ChangePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition()
    {
        randX = Random.Range(-240, 140);
        randZ = Random.Range(-240, 140);
        transform.position = new Vector3(randX, transform.position.y, randZ);
        
    }
}
