using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonObraScript : MonoBehaviour
{
    [SerializeField]
    public JSONReader.Obra obra
    {
        get {return m_obra; }
        set {m_obra = value; }
    }
    public JSONReader.Obra m_obra;
 

    public void ClickBotonObra() {
        Main.Instance.UserProfile.SetInfoObra(obra);
        GameObject pantallaObra = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        pantallaObra.SetActive(true);
    }
}
