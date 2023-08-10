using UnityEngine;
using UnityEngine.UI;

public class GTTB_Stairs : MonoBehaviour
{
    public AudioClip belladonnaRight;
    public AudioClip belladonnaLeft;
    public Button arrowLeft;
    public Button arrowRight;

    public GameController controller;                                                                                       // Reference to the GameController script

    private void Start()
    {
                                                                                                                            // Assign audio clips to buttons
        arrowLeft.onClick.AddListener(PlayRandomBelladonnaSound);
        arrowRight.onClick.AddListener(PlayRandomBelladonnaSound);
    }

    private void PlayRandomBelladonnaSound()
    {
        int randomIndex = Random.Range(0, 2);
        AudioClip randomClip = randomIndex == 0 ? belladonnaLeft : belladonnaRight;

                                                                                                                            // Play the selected sound
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(randomClip);

                                                                                                                            // Check if the clicked button matches the sound played
        if ((arrowLeft.GetComponent<AudioSource>().clip == randomClip && arrowLeft.interactable) ||
            (arrowRight.GetComponent<AudioSource>().clip == randomClip && arrowRight.interactable))
        {
            controller.WinConditionMet();                                                                                   // Call GameController's WinCondition
        }
        else
        {
            controller.LoseConditionMet();                                                                                  // Call GameController's LoseCondition
        }
    }
}