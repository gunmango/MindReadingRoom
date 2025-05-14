using System.Collections;
using UnityEngine;

public class LocationNoticeSetter : APopupSetter
{
    [SerializeField] private LocationNoticeUpdater _updater;

    private readonly float waitTime = 3f;
    public override void ShowPopup()
    {
        _updater.gameObject.SetActive(true);
        StartCoroutine(WaitCo());
    }

    public override void HidePopup()
    {
        _updater.gameObject.SetActive(false);
    }

    public override void SetPopup(object data)   
    {
        if (data is BookLocationData locationData)
        {
            _updater.SetText(locationData.shelfID);
        }
    }
    
    private IEnumerator WaitCo()
    {
        yield return new WaitForSeconds(waitTime);
        HidePopup();
    }
}
