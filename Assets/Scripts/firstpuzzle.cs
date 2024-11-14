using UnityEngine;

public class OrangeBook : MonoBehaviour
{
    public string disappearableTag = "disappear"; 
    private GameObject open_door;

    private void Start()
    {
       
        open_door = GameObject.FindWithTag("opendoor");
        if (open_door != null)
        {
            open_door.SetActive(false); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Book"))
        {
            
            GameObject[] objectsToDisappear = GameObject.FindGameObjectsWithTag(disappearableTag);

            foreach (GameObject obj in objectsToDisappear)
            {
                obj.SetActive(false); 
                Debug.Log("Disappearing object: " + obj.name);
            }

            
            if (open_door != null)
            {
                open_door.SetActive(true);
                Debug.Log("Door is now open.");
            }
            else
            {
                Debug.LogWarning("Open door object not found!");
            }
        }
    }
}
