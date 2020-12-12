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

    [SerializeField] private GameObject m_smokePrefab;
    [SerializeField] private GameObject m_particleContainer;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_isActive = !m_isActive;
            OnActivatedEvent?.Invoke(m_isActive);
            foreach(GameObject objectToSwap in m_objectsToSwap)
            {
                bool objectIsActive = objectToSwap.activeInHierarchy;
                objectToSwap.SetActive(!objectIsActive);
                Vector3 position = objectToSwap.transform.position;
                GameObject smoke = GameObject.Instantiate(m_smokePrefab);
                smoke.transform.position = position;
                smoke.transform.parent = m_particleContainer.transform;
                ParticleSystem smokeParticleSystem = smoke.GetComponent<ParticleSystem>();
                smokeParticleSystem.Play();
            }
            if (isKey)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
