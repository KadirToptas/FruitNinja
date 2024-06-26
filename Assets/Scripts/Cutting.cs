using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    public GameObject cutPrefab;

    public float cutLifeTime;

    private bool dragging;

    private Vector2 swipeStart;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            swipeStart = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && dragging)
        {
            dragging = false;
            CutSpawner();
        }
        
    }

    private void CutSpawner()
    {
        Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject cutInstance = Instantiate(cutPrefab, swipeStart, Quaternion.identity);
        
        cutInstance.GetComponent<LineRenderer>().SetPosition(0,swipeStart);
        cutInstance.GetComponent<LineRenderer>().SetPosition(1,swipeEnd);

        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = Vector2.zero;
        colliderPoints[1] = swipeEnd - swipeStart;

        cutInstance.GetComponent<EdgeCollider2D>().points = colliderPoints;
        
        Destroy(cutInstance, cutLifeTime);

    }
    
}
