using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Voice : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private Animator animator;


    private void Start() {
        actions.Add("move forward", Forward);
        actions.Add("back", Back);
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("move up", Up);
        actions.Add("down", Down);
        actions.Add("hi", Hi);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        animator = GetComponent<Animator>();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(0f, 0f, -1f);
    }

    private void Back()
    {
        transform.Translate(0f, 0f, 1f);
    }

    private void Left()
    {
        transform.Translate(1f, 0f, 0f);
    }

    private void Right()
    {
        transform.Translate(-1f, 0f, 0f);
    }

    private void Up()
    {
        transform.Translate(0f, 1f, 0f);
    }

    private void Down()
    {
        transform.Translate(0f, -1f, 0f);
    }

    private void Hi()
    {
        animator.SetTrigger("Hello");
    }
}
