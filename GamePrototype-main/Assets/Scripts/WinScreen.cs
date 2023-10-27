using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject BackgroundWinObject;
    public string targetTag = "Player";

    void Start() {
        BackgroundWinObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(targetTag)) {
            BackgroundWinObject.SetActive(true);
        }

        Debug.Log("collided");
    }   
}
