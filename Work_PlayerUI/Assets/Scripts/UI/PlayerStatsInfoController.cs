using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using UnityEngine.UI;


public class PlayerStatsInfoController : MonoBehaviour
{
    public string StateName;
    public int StateID;
    public string TextValue;
    public Sprite ImageValue;

    [SerializeField]
    private Text TextBox;

    [SerializeField]
    private Image ImageBox;

    void Start()
    {
        ImageValue = null;
        TextValue = "";
    }
 
    public static PlayerStatsInfoController CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerStatsInfoController>(jsonString);
    }

    void UpdateValues()
    {
        TextBox.gameObject.SetActive(true);
        if (TextValue != null && TextValue != "")
            TextBox.text = TextValue;
        //else
        //    TextBox.gameObject.SetActive(false);

        ImageBox.gameObject.SetActive(true);
        if(ImageValue != null)
            ImageBox.GetComponent<Image>().sprite = ImageValue;
        else
            ImageBox.gameObject.SetActive(false);
    }

    public void SetText(string newText)
    {
        TextValue = newText;
        UpdateValues();
    }

    public void SetImage(Sprite newImage)
    {
        ImageValue = newImage;
        UpdateValues();
    }

}
