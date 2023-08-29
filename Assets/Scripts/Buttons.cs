using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject[] Buttons_List;
    public AudioClip ButtonSound;

    private Vector3 _offset = new Vector3 (0, 0.004f, 0);
    private float _pushing_delay_time = 0.1f;
    private float _change_button_delay_time = 0.35f;
    private int _num_of_button;

    void Start()
    {
        Buttons_List = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject Button in Buttons_List)
        {
            Button.AddComponent(typeof(AudioSource));
            Button.GetComponent<AudioSource>().clip = ButtonSound;
        }
        StartCoroutine(PushButtons());
    }

    IEnumerator PushButtons()
    {
        _pushing_delay_time = Random.Range(0.05f, 0.15f);
        _change_button_delay_time = Random.Range(0.2f, 0.4f);
        _num_of_button = Random.Range(0, Buttons_List.Length);
        Buttons_List[_num_of_button].transform.position -= _offset;
        Buttons_List[_num_of_button].GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(_pushing_delay_time);
        Buttons_List[_num_of_button].transform.position += _offset;
        yield return new WaitForSecondsRealtime(_change_button_delay_time);
        StartCoroutine(PushButtons());
    }
}
