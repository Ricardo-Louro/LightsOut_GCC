using UnityEngine;

public class BatteryZone : MonoBehaviour
{
    [SerializeField] private GameObject darkness;
    private DoorOpener doorOpener;

    private void Start()
    {
        doorOpener = FindFirstObjectByType<DoorOpener>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null)
        {
            //DEACTIVATE BATTERY SPRITE
            //ACTIVATE PARTICLE EFFECT OF PICKUP
            darkness.SetActive(true);
            doorOpener.playerBattery = true;
        }
    }
}
