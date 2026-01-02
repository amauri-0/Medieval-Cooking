using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSucess += DeliveryManager_OnRecipeSucess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
    }

    private void DeliveryManager_OnRecipeFailed(object sender,System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliveryFail, Camera.main.transform.position);
    }

     private void DeliveryManager_OnRecipeSucess(object sender,System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverySucess, Camera.main.transform.position);
    }

    //Diferentes sons possiveis
      private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    //Um som
  private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position,volume);
    }
}

/*
Soundlist from pixabay

erro 1 https://pixabay.com/pt/sound-effects/error-126627/
erro 2 https://pixabay.com/pt/sound-effects/failed-c%c3%adrculo_vermelho-295059/

*/