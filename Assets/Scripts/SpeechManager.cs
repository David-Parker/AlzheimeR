﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        keywords.Add("Quit", () =>
        {
            Application.Quit();
        });

        keywords.Add("Clear All", () =>
        {
            // Delete all HoloObjects.
            var holoObjects = GameObject.FindGameObjectsWithTag("HoloObject").ToList();
            foreach (var ho in holoObjects)
            {
                Destroy(ho);
            }
        });

        keywords.Add("Delete", () =>
        {
            // Delete the focused object.
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                focusObject.SendMessage("OnDelete");
            }
        });

        keywords.Add("Drop Sphere", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnDrop method on just the focused object.
                focusObject.SendMessage("OnDrop");
            }
        });
        
        //switch to presentation mode
        keywords.Add("Ready", () =>
        {
            GameObject.Find("Setup").SetActive(false);
            gameObject.GetComponent<GazeGestureManager>().Enabled = false;
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}