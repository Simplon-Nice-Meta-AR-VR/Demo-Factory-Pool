using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePool : Pool
{
    [SerializeField] Factory spheresFactory;

    private List<Transform> sphereReferences;

    private void Start()
    {
        sphereReferences = new List<Transform>();
    }

    public override Transform Get(Vector3 position)
    {
        // V�rifier si une sph�re est disponible
        foreach (Transform t in sphereReferences)
        {
            if (!t.gameObject.activeInHierarchy)
            {
                t.gameObject.SetActive(true);
                t.position = position;
                t.GetComponent<Rigidbody>().velocity = Vector3.zero;
                return t;
            }
        }

        // Si aucune n'est disponible, on doit en g�n�rer une nouvelle
        Transform newSphere = spheresFactory.Generate(position);
        sphereReferences.Add(newSphere);
        return newSphere;
    }

    public override void Release(Transform element)
    {
        element.gameObject.SetActive(false);
    }
}
