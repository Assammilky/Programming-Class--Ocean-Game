using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RescueBoat : MonoBehaviour
{
    public GameObject m_passenger = null;
    private float m_timer = 0;
    public float m_rescueTime = 3;
    public float m_dropoffTime = 3;

    private bool m_hasPassenger = false;

    private void Start()
    {
        m_passenger.SetActive(false);
        m_hasPassenger = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Swimmer" && m_hasPassenger)
        {
            m_timer = 0;
        }
        else if (collider.gameObject.tag == "Dropzone" && m_hasPassenger == true)
        {
            m_timer = 0;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Swimmer" && m_hasPassenger == false)
        {
            m_timer += Time.deltaTime;
            Debug.Log((m_rescueTime / m_timer));
            if (m_timer >= m_rescueTime) 
            {
                PickupSwimmer(collider.gameObject);
            }
        }
        else if (collider.gameObject.tag == "Dropzone" && m_hasPassenger == true)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_dropoffTime)
            {
                DropoffSwimmer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_timer = 0;
    }

    public void PickupSwimmer (GameObject swimmer)
    {
        swimmer.SetActive(false);
        m_passenger.SetActive(true);
        m_hasPassenger = true;
    }
    public void DropoffSwimmer()
    {
        m_passenger.SetActive(false);
        m_hasPassenger = false;
    }
}



