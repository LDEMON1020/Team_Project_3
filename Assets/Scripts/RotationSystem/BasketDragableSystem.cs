using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketDragableSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDragging = false;

    public Camera mainCamera;
    public Vector3 dragOffset;
    public GameObject BasketObject;
    public float dragSpeed = 10f;

    public int BackSpeed = 5;

    public Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        { StartDragging(); }



        StopDragging();

        if (isDragging)
        {
            Vector3 targetPosition = GetMouseWorldPosition() + dragOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, dragSpeed * Time.deltaTime);

        }

        if (!isDragging)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, BackSpeed * Time.deltaTime);
        }

    }


    void StartDragging()
    {
        isDragging = true;
    }

    void StopDragging()
    {
        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
        }
    }



    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
