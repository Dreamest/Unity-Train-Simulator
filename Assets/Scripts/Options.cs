using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Options : MonoBehaviour
{
    public Slider aSlider;
    public Slider bSlider;

    public TMP_Text aText;
    public TMP_Text bText;

    // Start is called before the first frame update
    void Start()
    {
        aSlider.onValueChanged.AddListener (delegate {ValueChangeCheck (aSlider, aText);});
        aSlider.value = PlayerPrefs.GetInt(aSlider.name);
        bSlider.onValueChanged.AddListener (delegate {ValueChangeCheck (bSlider, bText);});
        bSlider.value = PlayerPrefs.GetInt(bSlider.name);

    }
    	public void ValueChangeCheck(Slider s, TMP_Text t)
	{
        PlayerPrefs.SetInt(s.name, (int)s.value);
        t.text = PlayerPrefs.GetInt(s.name).ToString();
	}

}
