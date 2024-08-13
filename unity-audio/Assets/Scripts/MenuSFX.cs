using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    private static MenuSFX instance;

    public AudioSource click;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static AudioSource GetButtonClickSound()
    {
        return instance.click;
    }
}
