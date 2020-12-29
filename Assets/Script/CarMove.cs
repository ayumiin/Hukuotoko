using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private carController script;
    public GameObject carpoints,car;
    public float speed = 23f;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Playerpoint");
        script = car.GetComponent<carController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.carMove == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, carpoints.transform.position, speed * Time.deltaTime);
        }
        
    }
}
