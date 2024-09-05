using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openURL : MonoBehaviour
{
    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/@collinballard7884");
    }

    public void LinkedIN()
    {
        Application.OpenURL("https://www.linkedin.com/in/collin-ballard/");
    }
    public void GitHub()
    {
        Application.OpenURL("https://github.com/Collinb190");
    }
    public void Email()
    {
        Application.OpenURL("mailto:collinb190@gmail.com");
    }
}
