using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    //[SerializeField] private Factory factory;
    [SerializeField] private Pool spheresPool;
    [SerializeField] private Spheres spheres;

    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //spheres.Add(factory.Generate(hit.point));
                spheres.Add(spheresPool.Get(hit.point));
            }
        }
    }
}
