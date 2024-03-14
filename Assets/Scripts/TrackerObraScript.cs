using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerObraScript : MonoBehaviour
{
    public void Desactivate() {
        foreach (Transform child in this.gameObject.transform)
            child.gameObject.SetActive(false);
    }

    public void Activate() {
        foreach (Transform child in this.gameObject.transform)
            child.gameObject.SetActive(true);
    }
}
