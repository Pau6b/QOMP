using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{


    // Start is called before the first frame update
    private bool enab = true;

    public bool GetIsEnabled()
    {
        return enab;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enab = false;
        }
    }

}
