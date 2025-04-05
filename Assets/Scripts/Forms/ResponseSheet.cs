using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseSheet : MonoBehaviour
{
    public string Name;
    public bool? hasPet;
    public bool? travelThroughEconomicZone;
    public string category;
    public string location;

    public static ResponseSheet instance { get; private set;}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
