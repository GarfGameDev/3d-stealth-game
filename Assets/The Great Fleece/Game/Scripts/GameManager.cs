using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    // Everything here is the singleton design pattern
    private static GameManager _instance;
    // This is a property
    public static GameManager Instance
    {
        
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return _instance;
        }
        
    }

    // This is an auto property
    public bool HasCard { get; set; }
    public PlayableDirector introCutscene;

    // Awake() is used at the instance Unity is loading
    private void Awake()
    {
        // this is being used to get this script that the object is attached to
        _instance = this;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 60.0f;
            AudioManager.Instance.PlayMusic();
        }
    }
}
