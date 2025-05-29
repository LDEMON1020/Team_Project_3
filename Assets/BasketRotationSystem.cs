using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketRotationSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 10f) * rotationSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -10f) * rotationSpeed * Time.deltaTime);
        }
    }
}
