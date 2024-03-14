using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile : MonoBehaviour
{
    public static string NombreImagen, Nombre, Autor, Origen, Fecha, Periodo, Escuela, Tecnica, Soporte, Medidas, Comentarios, Sala;
    public static JSONReader.Obra Obra;

    public void SetInfoObra(JSONReader.Obra obra)
    {
        Obra = obra;
        NombreImagen = obra.name;
        Nombre = obra.name;
        Autor = obra.author;
        Origen = obra.origin;
        Fecha = obra.date;
        Periodo = obra.period;
        Escuela = obra.school;
        Tecnica = obra.technique;
        Soporte = obra.support;
        Medidas = obra.messures;
        Comentarios = obra.comments;
        Sala = obra.exposition;
    }

    void Awake(){
          DontDestroyOnLoad(this.gameObject);
    }
}
