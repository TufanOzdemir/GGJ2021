using Assets.Scripts.DTO;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] GameObject InformationPanel;
    [SerializeField] GameObject ConfirmPanel;
    [SerializeField] GameObject MainPopupPanel;

    private Text TitleText;
    private Text DescriptionText;

    private Button OkButton;

    private Button ConfirmButton;
    private Button RejectButton;

    void Start()
    {
        TitleText = MainPopupPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
        DescriptionText = MainPopupPanel.transform.GetChild(1).gameObject.GetComponent<Text>();

        ConfirmButton = ConfirmPanel.transform.GetChild(0).gameObject.GetComponent<Button>();
        RejectButton = ConfirmPanel.transform.GetChild(1).gameObject.GetComponent<Button>();
        RejectButton.onClick.AddListener(Clear);

        OkButton = InformationPanel.transform.GetChild(0).gameObject.GetComponent<Button>();
        OkButton.onClick.AddListener(Clear);
    }

    public void ShowPopup(MainPopupDTO mainPopupDTO)
    {
        MainPopupPanel.SetActive(true);

        TitleText.text = mainPopupDTO.Title;
        DescriptionText.text = mainPopupDTO.Description;

        switch (mainPopupDTO.Type)
        {
            case PopupType.None:
                Clear();
                break;
            case PopupType.OkCancel:
                OkCancel(mainPopupDTO);
                break;
            case PopupType.Information:
                Information();
                break;
            case PopupType.Menu:
                Menu();
                break;
            case PopupType.MainMenu:
                MainMenu();
                break;
            case PopupType.SkillUpgrade:
                SkillUpgrade();
                break;
            default:
                Clear();
                break;
        }
    }

    private void Clear()
    {
        MainPopupPanel.SetActive(false);
        ConfirmPanel.SetActive(false);
        InformationPanel.SetActive(false);
    }
    private void OkCancel(MainPopupDTO mainPopupDTO)
    {
        ConfirmPanel.SetActive(true);
        ConfirmButton.onClick.RemoveAllListeners();
        ConfirmButton.onClick.AddListener(mainPopupDTO.OkButtonClickAction);
    }
    private void Information()
    {
        InformationPanel.SetActive(true);
    }
    private void MainMenu()
    {

    }
    private void Menu()
    {

    }
    private void SkillUpgrade()
    {

    }
}
