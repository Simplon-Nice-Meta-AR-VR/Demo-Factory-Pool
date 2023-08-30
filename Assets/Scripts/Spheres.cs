using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    [SerializeField] private float yThreshold = -6;

    private List<Transform> spheres;
    private List<Transform> toRemove;

    private void Start()
    {
        spheres = new List<Transform>();
        toRemove = new List<Transform>();
    }

    public void Add(Transform t)
    {
        spheres.Add(t);
    }

    void FixedUpdate()
    {
        toRemove.Clear();

        foreach (Transform t in spheres)
        {
            if (t.position.y < yThreshold)
            {
                Destroy(t.gameObject);
                toRemove.Add(t);
            }
        }

        if (toRemove.Count > 0)
        {
            spheres.RemoveAll(t => toRemove.Contains(t));
        }
    }
}
