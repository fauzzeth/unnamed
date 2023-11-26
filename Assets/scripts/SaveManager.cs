using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = other.transform.position;
            PlayerPrefs.SetFloat("PosX", playerPosition.x);
            PlayerPrefs.SetFloat("PosY", playerPosition.y);
            PlayerPrefs.SetFloat("PosZ", playerPosition.z);

            Debug.Log("Saved");
        }

    }

}
