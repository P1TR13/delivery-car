using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform car;
    public Transform actualCar;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            int hpChange = Random.Range(8, 12);
            gameManager.ChangeHP(-hpChange);
            car.transform.position = new Vector3(-20.7f, 1f, 42f);
            actualCar.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
