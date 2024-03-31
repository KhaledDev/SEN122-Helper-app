using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeekBtn_Tweener : MonoBehaviour
{
    
    private Vector3 oriscale;
    
    private void Start() {
        oriscale = transform.localScale;
    }
    
    public void ScaleBtn(float _desiredScale)
    {
        transform.DOScale(_desiredScale, 0.5f).SetEase(Ease.OutCubic);
    }
    
    public void deScaleBtn()
    {
        transform.DOScale(oriscale, 0.5f).SetEase(Ease.OutCubic);
    }
    
}
