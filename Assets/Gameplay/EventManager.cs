﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance => _instance;

    private void Awake()
    {
        Debug.Log("Event Manager instantiated");
        _instance = this;
    }

    public event Action OnCorrectKeyPressed;
    public void RaiseCorrectKeyPressed()
    {
        if (OnCorrectKeyPressed != null)
        {
            OnCorrectKeyPressed();
        }
    }

    public event Action OnIncorrectKeyPressed;
    public void RaiseIncorrectKeyPressed()
    {
        if(OnIncorrectKeyPressed != null)
        {
            OnIncorrectKeyPressed();
        }
    }

    public event Action OnCharacterDeleted;
    public void RaiseCharacterDeleted()
    {
        if(OnCharacterDeleted != null)
        {
            OnCharacterDeleted();
        }
    }

    public bool script_end_reached = false;
    public event Action OnScriptEndReached;
    public void RaiseScriptEndReached()
    {
        if(OnScriptEndReached != null && !script_end_reached)
        {
            Debug.Log("End of script is reached, a portal should be spawn to quit the current story");
            script_end_reached = true;
            OnScriptEndReached();
        }
    }

    private bool back_portal_opened;
    public event Action<Vector2> OnBackPortalOpen;
    public void RaiseBackPortalOpen(Vector2 end)
    {
        if (OnBackPortalOpen != null && !back_portal_opened)
        {
            back_portal_opened = true;
            Debug.Log("portals are now available");
            OnBackPortalOpen(end);
        }
    }

    public bool BackPortalOpened
    {
        get
        {
            return back_portal_opened;
        }
    }
    public event Action OnBackPortalClose;
    public void RaiseBackPortalClose()
    {
        if (OnBackPortalClose != null && back_portal_opened)
        {
            back_portal_opened = false;
            Debug.Log("portals are not unavailable");
            OnBackPortalClose();
        }
    }

    public void ScriptLoaded()
    {
        script_end_reached = false;
    }

    public event Action OnStartExitingScene;
    public void StartExitingScene()
    {
        if (OnStartExitingScene != null)
        {
            Debug.Log("exiting scene");
            OnStartExitingScene();
        }
    }

    public event Action OnStartEnteringScene;
    public void StartEnteringScene()
    {
        if (OnStartEnteringScene != null)
        {
            back_portal_opened = false;
            OnStartEnteringScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
