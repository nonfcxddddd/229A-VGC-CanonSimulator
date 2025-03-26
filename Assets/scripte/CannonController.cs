using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Transform cannonBase;   
    public Transform cannonBarrel; 

    public float baseRotationSpeed = 50f;  
    public float barrelRotationSpeed = 30f; 
    public float minBarrelAngle = -50f; 
    public float maxBarrelAngle = 20f;   

    private float currentBarrelAngle = 0f; 

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            cannonBase.Rotate(Vector3.up * horizontalInput * baseRotationSpeed * Time.deltaTime);
        }

       
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            currentBarrelAngle -= verticalInput * barrelRotationSpeed * Time.deltaTime;
            currentBarrelAngle = Mathf.Clamp(currentBarrelAngle, minBarrelAngle, maxBarrelAngle);
        }

       
        cannonBarrel.rotation = cannonBase.rotation * Quaternion.Euler(0, 0, currentBarrelAngle);
    }
}