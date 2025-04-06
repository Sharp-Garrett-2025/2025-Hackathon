using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FinalCalculations : MonoBehaviour
{
    private ResponseSheet responses;

    public TMP_Text userName;
    public TMP_Text location;
    public TMP_Text score;
    public TMP_Text employmentStatus;
    public TMP_Text returnAmount;

    public TMP_Text fact1;
    public TMP_Text fact2;
    public TMP_Text fact3;

    public TMP_Text ending;

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
            "You did not eat breakfast today",
            "You slept over 10 hours yesterday",
            "You really enjoy naps",
            "You have a heart of stone",
            "The work you do is mysterious and important",
            "Please enjoy all facts equally",
            "I'm in",
            "You haven't washed your bed sheets in a while"

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
            userName.text = "Name: " + responses.Name;
            location.text = responses.location;
            //score.text = pageManagerInstance.score;
            employmentStatus.text = responses.job;

            //fact1.text = pageManagerInstance.fact1;
            //fact2.text = pageManagerInstance.fact2;
            //fact3.text = pageManagerInstance.fact3;
        }
    }

    void getScore()
    {
        // Calculate the score based on the responses
        int sub = responses.errorCount * 5 + Random.Range(3,35);
        int scoreValue = 100 - sub;
        if(responses.lieTaxes == true)
        {
            scoreValue -= 50;
        }
        if(responses.pocketHoleTaxes == true)
        {
            scoreValue -= 5;
        }
        score.text = scoreValue.ToString() + "%";
        scoreValue = scoreValue * 13;
        returnAmount.text = "$" + scoreValue.ToString();
    }

    void getRank()
    {
        int sub = responses.errorCount * 5 + Random.Range(3, 35);
        int scoreValue = 100 - sub;
        // Calculate the rank based on the score
        if (scoreValue >= Random.Range(70, 100))
        {
            Ranks[0].SetActive(true);
            Ranks[1].SetActive(false);
            Ranks[2].SetActive(false);
            Ranks[3].SetActive(false);
            Ranks[4].SetActive(false);
        }
        else if (scoreValue >= Random.Range(50, 90))
        {
            Ranks[1].SetActive(true);
            Ranks[0].SetActive(false);
            Ranks[2].SetActive(false);
            Ranks[3].SetActive(false);
            Ranks[4].SetActive(false);
        }
        else if (scoreValue >= Random.Range(30, 70))
        {
            Ranks[2].SetActive(true);
            Ranks[0].SetActive(false);
            Ranks[1].SetActive(false);
            Ranks[3].SetActive(false);
            Ranks[4].SetActive(false);
        }
        else if (scoreValue >= Random.Range(10, 50))
        {
            Ranks[3].SetActive(true);
            Ranks[0].SetActive(false);
            Ranks[1].SetActive(false);
            Ranks[2].SetActive(false);
            Ranks[4].SetActive(false);
        }
        else
        {
            Ranks[4].SetActive(true);
            Ranks[0].SetActive(false);
            Ranks[1].SetActive(false);
            Ranks[2].SetActive(false);
            Ranks[3].SetActive(false);
        }
        string endingType;
        if(scoreValue>= 70)
        {
            endingType = "Big Ballin";
        }
        else if (scoreValue >= 50)
        {
            endingType = "Whatever";
        }
        else if (scoreValue >= 30)
        {
            endingType = "Jail";
        }
        else if (scoreValue >= 10)
        {
            endingType = "Gooner";
        }
        else
        {
            endingType = "Jail";
        }

        ending.text = "You have unlocked the <i>" + endingType + "</i> ending";
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

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
