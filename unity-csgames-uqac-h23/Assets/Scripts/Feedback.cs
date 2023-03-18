using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Feedback : MonoBehaviour
{
    [SerializeField] private TMP_Text hitText;
    [SerializeField] private TMP_Text reloadText;
    [SerializeField] private TMP_Text ammoText;

    public void setHitText(string text) {
        this.hitText.text = text;
        Invoke("clearHitText", 1.5f);
    }

    public void clearHitText() {
        this.hitText.text = "";
    }

    public void setReloadText(string text) {
        this.reloadText.text = text;
        Invoke("clearReloadText", 1.5f);
    }

    public void clearReloadText() {
        this.reloadText.text = "";
        setAmmoText("10");

    }

    public void setAmmoText(string text) {
        this.ammoText.text = text;
    }
}
