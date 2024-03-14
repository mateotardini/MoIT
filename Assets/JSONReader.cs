using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JSONReader : MonoBehaviour
{
    [SerializeField]
    public TextAsset textJson;
    [SerializeField]
    private GameObject BotonMenuPrefab;
    [SerializeField]
    private Transform ContentObras, ContentObrasItaliana;

    [System.Serializable]
    public class Obra{
        public string name, author, 
        origin, date, period, school, 
        technique, support, messures,
        comments, exposition;
    }

    [System.Serializable]
    public class ObrasList{
        public Obra[] obra;
    }

    public static ObrasList newObrasList = new ObrasList();

    void Start(){
        Load();
    }

    public void Load(){
        newObrasList = JsonUtility.FromJson<ObrasList>(textJson.text);
        foreach(Obra obra in newObrasList.obra){
             var newObra = Instantiate(BotonMenuPrefab, ContentObras);
             CreateButton(newObra, obra);
             
             if(obra.school.Contains("Italiana")){
                var newObraItaliana = Instantiate(BotonMenuPrefab, ContentObrasItaliana);
                CreateButton(newObraItaliana, obra);
             }
        }
    }

    public void CreateButton(GameObject newObra, JSONReader.Obra obra){
        newObra.transform.localScale = Vector3.one;
        newObra.name = obra.name;
        newObra.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Obras/ArteSigloXII-SigloSVIII/" + obra.name);
        newObra.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newObra.name;
        BotonObraScript script =newObra.GetComponent<BotonObraScript>();
        script.obra = obra;
    }
}
