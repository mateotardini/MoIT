using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PantallaObraScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text NombreTMP, SalaTMP, MedidasTMP, ComentariosTMP;
    public Image ImageObra;
    void OnEnable()
    {
        ImageObra.sprite = Resources.Load<Sprite>("Obras/ArteSigloXII-SigloSVIII/" + UserProfile.NombreImagen);
        NombreTMP.text = UserProfile.Nombre;
        SalaTMP.text = UserProfile.Sala;
        MedidasTMP.text = UserProfile.Medidas;
        ComentariosTMP.text = UserProfile.Comentarios;
    }
}
