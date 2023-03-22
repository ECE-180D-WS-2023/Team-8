using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class SpeechRecognition : MonoBehaviour
{
    private KeywordRecognizer m_Recognizer;
    private string[] m_Keywords;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        //m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    //private void OnPhraseRecognized(
}

public class MainMenu : MonoBehaviour


{
    int n;
    public void OnButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Add function for button attached to Play that does SceneManager.LoadScene("SongMenu");
        // after adding the SongMenu scene to the scenes under build settings.
        // Put a button over each song that loads the appropriate scene for that given song.
    }

    public void Options()
    {
        Debug.Log("Options menu selected.");
        //SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("Quitting the game.");
        // (Quit)
    }



    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
    }
    
}
