using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PopupDOTween : MonoBehaviour
{
    public RectTransform[] popupPanels;
    public GameObject[] popupPanelGOs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var popupPanelGO in popupPanelGOs)
        popupPanelGO.SetActive(false);
        foreach (var popupPanel in popupPanels)
        popupPanel.localScale = Vector3.zero; // Hide First

        //POPUP panel[1]
        popupPanelGOs[1].SetActive(true);
        popupPanels[1].DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);        
    }

    // Update is called once per frame
    public void ShowPopup(int index)
    {   
        ClosePopup(index);
        if(index <popupPanelGOs.Length && index <  popupPanels.Length )
        {
            popupPanelGOs[index].SetActive(true);
            popupPanels[index].DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack); // popup to show
        }
    }
    // Close Popup
    public void ClosePopup(int index)
    {
        for(int i = 0; i < popupPanels.Length;i++)
        {
            if(i!=index)
            popupPanels[i].DOScale(Vector3.zero, 0.1f).SetEase(Ease.InBack); //  popup to close
        }
    }

    // Close Popup ignore index   
    public void ClosePopupignore(int index)
    {
        for(int i = 0; i < popupPanels.Length;i++)
        {
            popupPanels[i].DOScale(Vector3.zero, 0.1f).SetEase(Ease.InBack); //  popup to close
        }
    }   
}
