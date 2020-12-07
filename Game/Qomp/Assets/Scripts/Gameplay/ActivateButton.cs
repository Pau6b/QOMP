using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{


    // Start is called before the first frame update
    public delegate void ActivatedEvent(bool i_isActivated);
    public ActivatedEvent OnActivatedEvent;

    [SerializeField] List<GameObject> m_objectsToSwap;
    [SerializeField] bool isKey = true;
    private bool m_isActive = false;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_isActive = !m_isActive;
            OnActivatedEvent?.Invoke(m_isActive);
            foreach(GameObject objectToSwap in m_objectsToSwap)
            {
                bool objectIsActive = objectToSwap.activeInHierarchy;
                objectToSwap.SetActive(objectIsActive);
            }
            if (isKey)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
