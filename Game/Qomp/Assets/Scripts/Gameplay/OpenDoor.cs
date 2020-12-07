using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<ActivateButton> m_buttons;
    private int m_buttonNumberActivated = 0;
    private int m_totalNumberOfKeys;

    void Start()
    {
        m_totalNumberOfKeys = m_buttons.Count;
        foreach(ActivateButton button in m_buttons)
        {
            button.OnActivatedEvent += OnButtonActivated;
        }
    }

    void OnButtonActivated(bool i_isActive)
    {
        if(i_isActive)
        {
            m_buttonNumberActivated++;
        }
        else
        {
            m_buttonNumberActivated--;
        }
        if (m_buttonNumberActivated == m_totalNumberOfKeys)
        {
            foreach (ActivateButton button in m_buttons)
            {
                button.OnActivatedEvent -= OnButtonActivated;
            }
            Destroy(this.gameObject);
        }
    }
}
