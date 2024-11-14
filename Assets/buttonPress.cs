using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public int buttonNumber; 
    private RiddleDoor riddleDoor;

    void Start()
    {
        riddleDoor = FindObjectOfType<RiddleDoor>();
    }

    void OnMouseDown()
    {
        riddleDoor.ButtonPressed(buttonNumber);
    }
}
