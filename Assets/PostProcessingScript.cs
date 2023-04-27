using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingScript : MonoBehaviour
{
    [SerializeField] private Volume M_PPVol;
    Vignette m_Vignette;
    ColorAdjustments m_ColorAd;
    DepthOfField m_DoF;



    void Start()
    {
        M_PPVol = gameObject.GetComponent<Volume>();

    }

    public void IncreaseVignette()
    {
        if (M_PPVol.profile.TryGet<Vignette>(out m_Vignette) && m_Vignette.intensity.value < 1f)
        {
            m_Vignette.intensity.value += 0.035f * Time.deltaTime ;
        }
    }

    public void ResetVignette()
    {
        if (M_PPVol.profile.TryGet<Vignette>(out m_Vignette))
        {
            m_Vignette.intensity.value = 0.15f;
        }
    }

    public void DecreaseVignette()
    {
      
        if (M_PPVol.profile.TryGet<Vignette>(out m_Vignette) && m_Vignette.intensity.value > 0.1f)
        {
            m_Vignette.intensity.value -= 0.35f * Time.deltaTime;
        }
    }

    public void DecreaseSaturation()
    {
        if(M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd) && m_ColorAd.saturation.value > -55)
        {
            print("decrease saturation");
            m_ColorAd.saturation.value -= 5f * Time.deltaTime;
        }
    }
    public void RestoreSaturation()
    {
        if (M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd))
        {
            m_ColorAd.saturation.value = 26;
        }

    }

    public void DecreasePostExp()
    {
        if (M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd) && m_ColorAd.postExposure.value > -10.0)
        {
            m_ColorAd.postExposure.value -= 2f * Time.deltaTime;
        }
    }


    public void IncreasePostExp()
    {
        if (M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd) && m_ColorAd.postExposure.value < 15)
        {
            m_ColorAd.postExposure.value += 2f * Time.deltaTime;
        }
    }

    public void ResetPostExp()
    {
        if (M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd) && m_ColorAd.postExposure.value > 0)
        {
            m_ColorAd.postExposure.value -= 0.2f * Time.deltaTime *10;
            print("exposure being decreased");
        }

        else if (M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd) && m_ColorAd.postExposure.value < 0)

        {
            m_ColorAd.postExposure.value += 0.2f * Time.deltaTime *10;
            print("exposure being increased");
        }

         if(M_PPVol.profile.TryGet<ColorAdjustments>(out m_ColorAd) && m_ColorAd.postExposure.value <  0.4f && m_ColorAd.postExposure.value > -0.4f)
        {
            m_ColorAd.postExposure.value = 0;
            print("exposure zero");
            if (m_ColorAd.postExposure.value == 0)
            {
                DeathScript.ResetPostExp = false;
                return;
            }
        }
    }    


}
