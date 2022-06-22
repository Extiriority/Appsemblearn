using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSounds : MonoBehaviour
{
    public void OpenDoorSound()
    {
        SoundManager.instance.play("Door Open");
    }

    public void CloseDoorSound()
    {
        SoundManager.instance.play("Door Close");
    }
}
