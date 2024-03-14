using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAR : MonoBehaviour
{
    public GameObject NewSpritePrefab;


    public void createImageTracker()
    {
        StartCoroutine(createImageTargetFromResources());
    }

    IEnumerator createImageTargetFromResources()
    {
        JSONReader.Obra obra = UserProfile.Obra;
        Debug.Log(obra.name);
        if (obra != null)
            {
                // Create Texture from selected image in resources
                Texture2D texture =  Resources.Load<Texture2D>("Obras/ArteSigloXII-SigloSVIII/" + obra.name);
                Debug.Log(texture);
                if (texture == null)
                {
                    Debug.Log("Error");
                }
                else
                {
                    //Make texture redable
                    texture = getTextureCopy(texture);

                    //instantiate ImageTracker
                    var objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

                    // get the runtime image source and set the texture
                    var runtimeImageSource = objectTracker.RuntimeImageSource;
                    runtimeImageSource.SetImage(texture, 0.15f, obra.name);

                    // create a new dataset and use the source to create a new trackable
                    var dataset = objectTracker.CreateDataSet();
                    var trackableBehaviour = dataset.CreateTrackable(runtimeImageSource, obra.name);

                    // add the DefaultTrackableEventHandler to the newly created game object
                    trackableBehaviour.gameObject.AddComponent<DefaultTrackableEventHandler>();

                    // activate the dataset
                    objectTracker.ActivateDataSet(dataset);

                    // TODO: add virtual content as child object(s)
                    Sprite renderer = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector3(0.5f, 0.5f, 0), 1000);
                }
            }
        yield return new WaitForSeconds(0.1f);
    }

    Texture2D getTextureCopy(Texture2D image)
    {
        RenderTexture tmp = RenderTexture.GetTemporary(image.width, image.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        // Blit the pixels on texture to the RenderTexture
        Graphics.Blit(image, tmp);
        // Backup the currently set RenderTexture
        RenderTexture previous = RenderTexture.active;
        // Set the current RenderTexture to the temporary one we created
        RenderTexture.active = tmp;
        // Create a new readable Texture2D to copy the pixels to it
        Texture2D myTexture2D = new Texture2D(image.width, image.height);
        // Copy the pixels from the RenderTexture to the new Texture
        myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
        myTexture2D.Apply();
        myTexture2D.Compress(false);
        // Reset the active RenderTexture
        RenderTexture.active = previous;
        // Release the temporary RenderTexture
        RenderTexture.ReleaseTemporary(tmp);
        return myTexture2D;
    }

}
