using UnityEngine;


public class VRSwitchToggle : MonoBehaviour
{
    public GameObject switchObject;
    public GameObject Osecretpassage;
    private bool isSwitchOn = false;
    public Material onMaterial;
    public Material offMaterial;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor leftRayInteractor;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightRayInteractor;

    void Start()
    {
        GameObject leftController = GameObject.Find("LeftHand Controller");
        GameObject rightController = GameObject.Find("RightHand Controller");

        if (leftController != null)
        {
            leftRayInteractor = leftController.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor>();
        }
        else
        {
            Debug.LogError("LeftHand Controller not found. Check the GameObject name.");
        }

        if (rightController != null)
        {
            rightRayInteractor = rightController.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor>();
        }
        else
        {
            Debug.LogError("RightHand Controller not found. Check the GameObject name.");
        }

        UpdateSwitchVisual();
    }

    void Update()
    {
        if (IsSwitchTouched())
        {
            if (IsTriggerPressed())
            {
                ToggleSwitch();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ToggleSwitch();
            }
        }
    }

    private bool IsSwitchTouched()
    {
        if (leftRayInteractor == null || rightRayInteractor == null)
        {
            Debug.LogError("Ray Interactors not set. Check Start() for errors.");
            return false;
        }

        RaycastHit hit;

        if (leftRayInteractor.TryGetCurrent3DRaycastHit(out hit) || rightRayInteractor.TryGetCurrent3DRaycastHit(out hit))
        {
            return hit.collider != null && hit.collider.CompareTag("Switch");
        }

        return false;
    }

    private bool IsTriggerPressed()
    {
        
        return Input.GetButtonDown("XRInput.LeftTrigger") || Input.GetButtonDown("XRInput.RightTrigger");
    }

    private void ToggleSwitch()
    {
        isSwitchOn = !isSwitchOn;
        UpdateSwitchVisual();

        if (isSwitchOn)
        {
            Osecretpassage.SetActive(false);
        }
        else
        {
            Osecretpassage.SetActive(true);
        }

        Debug.Log("Switch turned " + (isSwitchOn ? "ON" : "OFF"));
    }

    private void UpdateSwitchVisual()
    {
        switchObject.GetComponent<Renderer>().material = isSwitchOn ? onMaterial : offMaterial;
    }
}
