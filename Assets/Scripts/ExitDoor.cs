using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool open = false;

    public void Open()
    {
        //SWITCH SPRITE TO OPEN DOOR

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null && open)
        {
            //COMPLETE LEVEL
        }
    }
}