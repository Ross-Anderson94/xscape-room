using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isGrabbing = false;
    private GameObject grabbedObject;
    private float grabDistance = 2f;
    public string resetTag = "ResetPoint";
    public float maxDistance = 5f;
    private bool toggleTunnel = true;

    private Transform resetPosition;

    public GameObject player;
    public GameObject tunnel;

    // The distance between the camera and the player.
    private Vector3 offset;
    private Vector3 offsetFromBall = new Vector3(0, 3, 3);
    private Vector3 targetPosition = new Vector3(1, 1, 1);
    private Vector3 targetRotation = new Vector3(0, 0, 0);

    // Start is called before the first frame update.
    void Start()
    {
        tunnel = GameObject.FindWithTag("Tunnel");
        // Calculate the initial offset between the camera's position and the player's position.
        Debug.Log("Start");
        Debug.Log(offset);
        Debug.Log(transform);
        Debug.Log(player.transform);
        Debug.Log("Start D");

        offset = transform.position - player.transform.position;
        Debug.Log(offset);
        Debug.Log("Start E");
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position + offset;
    }

    void Update()
    {

       

        if (Input.GetKeyDown(KeyCode.B))
        {
            
            GameObject objectToMove = GameObject.FindWithTag(resetTag);
            if(objectToMove !=null)
            {

               
                // Get the player's transform
                Transform playerTransform = Camera.main.transform;

                // Makes the ball appear in front of you
                Vector3 targetPosition = playerTransform.position + playerTransform.forward * offsetFromBall.z + playerTransform.up * offsetFromBall.y + playerTransform.right * offsetFromBall.x;

                // Set the balls position to this new target position
                objectToMove.transform.position = targetPosition;

                // makes ball stop moving
                Rigidbody rb = objectToMove.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

                // Align the object's rotation to match the player/camera's rotation
                Quaternion targetRotation = Quaternion.LookRotation(playerTransform.forward, playerTransform.up);
                objectToMove.transform.rotation = targetRotation;
            }
        }
         
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggles tunnel vision on/off
            if (toggleTunnel == true){
            tunnel.SetActive(false);
                toggleTunnel = false;
            }
            else
            {
                tunnel.SetActive(true);
                toggleTunnel= true;
            }

        }
       
        
    }


}