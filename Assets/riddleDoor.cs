using UnityEngine;
using System.Collections.Generic;

public class RiddleDoor : MonoBehaviour
{
    public GameObject riddleDoor;
    public GameObject[] buttons; 

    private int[] correctOrder = {1, 2, 3}; 
    private List<int> playerInput = new List<int>();

    public void ButtonPressed(int buttonNumber)
    {
        playerInput.Add(buttonNumber);

        if (playerInput.Count == correctOrder.Length)
        {
            if (IsCorrectOrder())
            {
                Debug.Log("Riddle Solved!");
                riddleDoor.SetActive(false); 
                foreach (var button in buttons)
                {
                    button.SetActive(false); 
                }
            }
            else
            {
                Debug.Log("Try again.");
                playerInput.Clear(); 
            }
        }
    }

    private bool IsCorrectOrder()
    {
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (playerInput[i] != correctOrder[i])
            {
                return false;
            }
        }
        return true;
    }
}
