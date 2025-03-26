using UnityEngine;
using System.Collections;
public class CollectiblePart : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Renderer objectRenderer;
    private Collider objectCollider;
    public GameObject hitEffect; 

    void Start()
    {
      
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

     
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
       
        objectRenderer.enabled = false;
        objectCollider.enabled = false;

    
        yield return new WaitForSeconds(3f);

        
        transform.position = initialPosition;
        transform.rotation = initialRotation;

      
        objectRenderer.enabled = true;
        objectCollider.enabled = true;
    }
}
