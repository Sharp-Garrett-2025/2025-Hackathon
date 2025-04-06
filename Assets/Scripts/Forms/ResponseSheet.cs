using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseSheet : MonoBehaviour
{
    public string Name;
    public bool? hasPet = null;
    public bool? travelThroughEconomicZone= null;
    public bool? hasQuantum = null;
    public bool? clickFruad = null;
    public bool? temporalInformation= null;
    public bool? fabricManipulator = null;
    public bool? quantumTaxEvasion = null;
    public bool? legalEntityBinding = null;
    public bool? pocketHoleTaxes = null;
    public bool? catGirlGambling = null;
    public bool? lieTaxes = null;

    public string category= "";
    public string location = "";
    public string demensionalEntity = "";

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
