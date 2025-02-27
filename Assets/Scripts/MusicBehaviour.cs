using UnityEngine;

public class MusicBehaviour : MonoBehaviour
{
    private static MusicBehaviour musicBehaviour;

    private void Awake()
    {
        if(musicBehaviour is null)
        {
            musicBehaviour = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}