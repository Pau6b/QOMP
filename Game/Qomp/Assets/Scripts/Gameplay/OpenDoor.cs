using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private ActivateButton m_button1, m_button2, m_button3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_button1.enab && !m_button2.enab && !m_button3.enab)
        {
            Destroy(this.gameObject);
        }
    }
}
