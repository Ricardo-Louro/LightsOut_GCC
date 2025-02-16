using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public bool playerBattery = false;
    private ExitDoor exitDoor;

    private void Start()
    {
        exitDoor = FindFirstObjectByType<ExitDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null && playerBattery)
        {
            //BATTERY APPEAR ON SLOT
            //SPARKLES AND SHIT
            exitDoor.Open();
            Destroy(this);
        }
    }
}
