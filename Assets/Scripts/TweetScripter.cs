using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetScripter : MonoBehaviour {

    private string tweet;
    private int subject;
    private GameObject tweetWindow;
    private string[] tweetQuotes = new string[100];

    public AudioClip[] otherClip; //make an arrayed variable (so you can attach more than one sound)

    // Play random sound from variable
    void PlaySound(int i)
    {
        //Assign random sound from variable
        GetComponent<AudioSource>().clip = otherClip[i];

        GetComponent<AudioSource>().Play();
    }

    IEnumerator SpawnTweet()
    {
        yield return new WaitForSeconds(3);

        while (Camera.main.GetComponent<GameManager>().IsGameStarted())
        {
            yield return new WaitForSeconds(1);
            if(Random.Range(0,10) == 3)
            {
                tweetWindow.SetActive(true);
                int numTweet = 0;
                subject = Random.Range(0, 4);

                //subject:    0-Random subject, no particular bonuses 1-Woman 2-Man 3-Trump is happy about what you do 4-Trump is not happy about what you do
                switch (subject)
                {
                    case 0:
                        numTweet = Random.Range(0, 3);
                        tweet = tweetQuotes[(numTweet + 10)];
                        break;
                    case 1:
                        numTweet = Random.Range(0, 4);
                       tweet = tweetQuotes[(numTweet + 20)];
                        break;
                    case 2:
                        numTweet = Random.Range(0, 3);
                        tweet = tweetQuotes[(numTweet + 30)];
                        break;
                    case 3:
                        numTweet = Random.Range(0, 3);
                        tweet = tweetQuotes[(numTweet + 40)];
                        break;
                    case 4:
                        numTweet = Random.Range(0, 2);
                        tweet = tweetQuotes[(numTweet + 50)];
                        break;
                }

                tweetWindow.GetComponentInChildren<TextMesh>().text = tweet;

                yield return new WaitForSeconds(15);
                tweetWindow.SetActive(false);
                tweetWindow.GetComponentInChildren<TextMesh>().text = "";
            }
        }
    }

    public int tweetSubject()
    {
        return subject;
    }

    // Use this for initialization
    void Start () {

        tweetWindow = Instantiate(Resources.Load("TweetBackground", typeof(GameObject))) as GameObject;
        tweet = "";
        subject = 0;
        tweetWindow.SetActive(false);
        tweetWindow.GetComponentInChildren<TextMesh>().text = tweet;
        StartCoroutine(SpawnTweet());

        tweetQuotes[10] = "Make America great again!";
        tweetQuotes[11] = "Big interview tonight at Fox News";
        tweetQuotes[12] = "www.p*rnhu8.com/trump\nDon't botter the last tweet! i thought i was on google.";
        tweetQuotes[13] = "Screw the other countries...";

        tweetQuotes[20] = "Grab them by the pu**y!";
        tweetQuotes[21] = "Hillary Clinton should be in jail!";
        tweetQuotes[22] = "Woman should not have the rigth to vote, they are dumb.";
        tweetQuotes[23] = "Most of women are stupid, cheaters, liars, can't think right.\nOther than that their body are great.";
        tweetQuotes[24] = "Must be a pretty picture mexican's women dropping on their knees";

        tweetQuotes[30] = "Illegal immigrants are stealing our jobs! We need more men \nto build that wall.";
        tweetQuotes[31] = "The problem with mexican people is that they don't know how \nto make tacos.";
        tweetQuotes[32] = "Send the mexicans back in to their cage  !";  
        tweetQuotes[33] = "''Immigrants are Trump's ennemies'', FAKE NEWS! They are \nAMERICA'S ennemies !";

        tweetQuotes[40] = "The U.S. military are doing a great job at the mexican border!";
        tweetQuotes[41] = "We are intercepting a lot of illegal mexican immigrants";
        tweetQuotes[42] = "The wall is getting bigger!";
        tweetQuotes[43] = "100 000 000 $ military budget as been established for \nthe mexican border";

        tweetQuotes[50] = "The General of 'the operation illegal immigrant' is an incapable";
        tweetQuotes[51] = "Come on troups! get rid of those mexicans!";
        tweetQuotes[52] = "My grandmother could be more efficient than the custom officers";
    }
}