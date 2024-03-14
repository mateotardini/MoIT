using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PantallaPrincipal : MonoBehaviour
{
    [SerializeField]
    private GameObject PantallaObra, PantallaMuseo, AllObras;
    [SerializeField]
    private Image[] ImageFeatured;
    [SerializeField]
    private TMP_Text[] NombreFeatured;

    private void Start()
    {
        Screen.fullScreen = false;
        PickFeatured();
    }

    public void PickFeatured() {
        for (int j = 0; j < 2; j++)
        {
            int randomNum = Random.Range(0, JSONReader.newObrasList.obra.Length);
            string nameObra = JSONReader.newObrasList.obra[randomNum].name; 
            ImageFeatured[j].sprite = Resources.Load<Sprite>("Obras/ArteSigloXII-SigloSVIII/" + nameObra);
            NombreFeatured[j].text = nameObra;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PantallaMuseo.activeSelf)
                CerrarMuseo();
            else if (PantallaObra.activeSelf)
                CerrarObras();
        }
    }



    #region Botones
    public void CerrarObras() {
        PantallaObra.SetActive(false);
    }
    public void CerrarMuseo()
    {
        PantallaMuseo.SetActive(false);
    }


    public void Escanear() {
        StartCoroutine(LoadYourAsyncScene());
    }

    public void Explorar() {
        SceneManager.LoadSceneAsync("PantallaPrincipal");
    }

    public void Visitanos() {
        Application.OpenURL("https://www.bellasartes.gob.ar/");
    }
    public void Ubicacion()
    {
        Application.OpenURL("https://www.google.com/maps/place/Museo+Nacional+de+Bellas+Artes/@-34.5839894,-58.3930044,15z/data=!4m2!3m1!1s0x0:0x49e543b8331abe7d?sa=X&ved=2ahUKEwim0JK_nPrvAhX6GrkGHXixAYYQ_BIwGnoECEEQBQ");
    }
    #endregion

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Escaner");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
