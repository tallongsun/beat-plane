using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour {

    public GameObject bomb;
    public GUIText bombNumber;

    public int count=0;

    public static BombManager _instance;
    void Awake() {
        _instance = this;
        bomb.SetActive(false);
        bombNumber.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && BombManager._instance.count > 0) {
            this.UseABomb();
        }
    }

    public void AddABomb() {
        bomb.SetActive(true);
        bombNumber.gameObject.SetActive(true);
        count++;
        bombNumber.text = "X " + count;
    }


    private void UseABomb() {
        if (count > 0) {
            GetComponent<AudioSource> ().Play ();
            count--;
            bombNumber.text = "X " + count;
            if (count <= 0) {
                bomb.SetActive(false);
                bombNumber.gameObject.SetActive(false);
            }
        }
    }

}
