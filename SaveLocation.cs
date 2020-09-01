using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveLocation : MonoBehaviour
{
    public int objects = 5; // create array of 5 objects
    public GameObject[] objectArr; // array of objects
    public Vector3 destination;

    

    //position
    public float thisobjXposition;
    public float thisobjYposition;
    public float thisobjZposition;

    //rotation
    public float thisobjXrotation;
    public float thisobjYrotation;
    public float thisobjZrotation;

    public void Awake()
    {
        thisobjXposition = PlayerPrefs.GetFloat("MyPositionX"); // gets the saved position.x from player prefs and fills my variable with info
        thisobjYposition = PlayerPrefs.GetFloat("MyPositionY"); // gets the saved position.y from player prefs and fills my variable with info
        thisobjZposition = PlayerPrefs.GetFloat("MyPositionZ"); // gets the saved position.z from player prefs and fills my variable with info

        thisobjXrotation = PlayerPrefs.GetFloat("MyRotationX"); // gets the saved rotation.x from player prefs and fills my variable with info
        thisobjYrotation = PlayerPrefs.GetFloat("MyRotationY"); // gets the saved rotation.y from player prefs and fills my variable with info
        thisobjZrotation = PlayerPrefs.GetFloat("MyRotationZ"); // gets the saved rotation.z from player prefs and fills my variable with info


    }

    public void Start()
    {
        //Create the folder
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Chat_Logs/");
        transform.position = new Vector3(thisobjXposition, thisobjYposition, thisobjZposition); // sets the position of the transform character.
        transform.rotation = Quaternion.Euler(thisobjXrotation, thisobjYrotation, thisobjZrotation); // sets the rotation of the transform character.
        CreateTextFile();
    }

    public void CreateTextFile()
    {
        

        // create the .txt at the already created directory in the start function
        string objectDocumentationName = (Application.streamingAssetsPath + "/Chat_Logs/" + "Object_position" + ".txt");

       
        //check to see if file exists
        if (!File.Exists(objectDocumentationName))
        {
            //add a heading insde the .txt file date created
           File.WriteAllText(objectDocumentationName, " Updated Object Position File \n\n");
          
        }

        // Any text that is still in the input field wil be sent to the log
        File.AppendAllText(objectDocumentationName, thisobjXposition + "\n\n");
        File.AppendAllText(objectDocumentationName, thisobjYposition + "\n\n");
        File.AppendAllText(objectDocumentationName, thisobjZposition + "\n\n");

    }
    public void Update()
    {
        PlayerPrefs.SetFloat("MyPostionX", transform.position.x);
        PlayerPrefs.SetFloat("MyPostionY", transform.position.y);
        PlayerPrefs.SetFloat("MyPostionZ", transform.position.z);


    }
}
