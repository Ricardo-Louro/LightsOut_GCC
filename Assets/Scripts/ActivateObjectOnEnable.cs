using UnityEngine;

public class ActivateObjectOnEnable : MonoBehaviour
{
    [SerializeField] private GameObject activatable;

    private void Start()
    {
        activatable.SetActive(true);
    }
}
