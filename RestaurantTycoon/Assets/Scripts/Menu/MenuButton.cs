using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject objectToEnable;
    Button thisButton;
    public enableChild ParentClass;
    [SerializeField]
    int menuReferenceNo = 0;
    private new AudioSource audio;
    public AudioClip toggle1;
    public AudioClip toggle2;

    void Start()
    {
        audio = ParentClass.gameObject.GetComponent<AudioSource>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(enable);
        objectToEnable.SetActive(false);
    }

    public void enable()
    {
        if (!objectToEnable.activeSelf)
        {
            audio.clip = toggle1;
            audio.Play();
            ParentClass.GetComponent<enableChild>().enable(menuReferenceNo);
        }
        else
        {
            audio.clip = toggle2;
            audio.Play();
            ParentClass.GetComponent<enableChild>().disable();
        }
    }


}
