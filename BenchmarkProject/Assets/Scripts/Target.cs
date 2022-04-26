using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(this.gameObject);
        AimTrainer.canSpawn = true;
        AimTrainer.counting = false;
    }
}
