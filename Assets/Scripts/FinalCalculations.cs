using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalCalculations : MonoBehaviour
{
    private ResponseSheet responses;

    public TMP_Text userName;
    public TMP_Text location;
    public TMP_Text score;
    public TMP_Text employmentStatus;

    public TMP_Text fact1;
    public TMP_Text fact2;
    public TMP_Text fact3;

    public List<GameObject> Ranks;

    public List<string> facts = new List<string>();

    private void Awake()
    {
        facts = new List<string> { "You did not floss today",
            "You are into rock sculpting",
            "You are good at intercourse",
            "You are a good person",
            "You are a bad person",
            "You are into rock climbing",
            "You are weak willed",
            "I despise you...",
            "Get out of my house",
            "You are paranoid",
            "You are a very meticulius person",
            "You are a liar",
            "You are bad at cooking",
            "You need to do laundry",
            "You are a good cook",
            "You have a good sense of humor",
            "You like grape juice",
            "You hate grape juice",
            "You will vote this game to win",
            "Wake up",
            "Those pants do not match your shirt",
            "You have an interesting personality",
            "You breathe loudly",
            "You walk quietly",
            "You walk loudly",
            "You completed this form very slowly",
            "You are a very fast person",
            "Congratulations, you are a human being",
            "You are a very slow person",
            "I sense you have a lot of dread",
            "You have many secrets",
            "You want more than you have",
            "Your favorite color is blue",
            "You like creamer more than coffee",
            "You drink your coffee black",
            "You do not make a lot of money",
            "You did not take taxes seriously",
            "You did not eat breakfast today"

        };
        responses = FindObjectOfType<ResponseSheet>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnFinalStart()
    {
        getUserInfo();
        getScore();
        getRank();
        getFacts();
    }

    void getUserInfo()
    {
        if (responses != null)
        {
            userName.text = responses.Name;
            //location.text = responses.location;
            //score.text = pageManagerInstance.score;
            //employmentStatus.text = responses.employmentStatus;

            //fact1.text = pageManagerInstance.fact1;
            //fact2.text = pageManagerInstance.fact2;
            //fact3.text = pageManagerInstance.fact3;
        }
    }

    void getScore()
    {
        // Calculate the score based on the responses
        int scoreValue = 100;
        if(responses.lieTaxes == true)
        {
            scoreValue -= 50;
        }
        if(responses.pocketHoleTaxes == true)
        {
            scoreValue -= 5;
        }
        if(responses.demensionalEntity == "The Galactic Data Syndicate")
        {
            scoreValue += 50;
        }
        score.text = scoreValue.ToString();
    }

    void getRank()
    {
        // Calculate the rank based on the score
        int scoreValue = int.Parse(score.text);
        if (scoreValue >= Random.Range(70, 100))
        {
            Ranks[0].SetActive(true);
        }
        else if (scoreValue >= Random.Range(50, 90))
        {
            Ranks[1].SetActive(true);
        }
        else if (scoreValue >= Random.Range(30, 70))
        {
            Ranks[2].SetActive(true);
        }
        else if (scoreValue >= Random.Range(10, 50))
        {
            Ranks[3].SetActive(true);
        }
        else
        {
            Ranks[4].SetActive(true);
        }
    }

    void getFacts()
    {
        System.Random random = new System.Random();
        List<string> selectedFacts = new List<string>();

        while (selectedFacts.Count < 3)
        {
            int index = random.Next(facts.Count);
            string fact = facts[index];
            if (!selectedFacts.Contains(fact))
            {
                selectedFacts.Add(fact);
            }
        }

        fact1.text = selectedFacts[0];
        fact2.text = selectedFacts[1];
        fact3.text = selectedFacts[2];
    }
}
