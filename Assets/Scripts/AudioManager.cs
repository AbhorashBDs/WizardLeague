using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager p_instance = null;
    public static AudioManager Instance { get { return p_instance; } }

    private AudioSource musique;

    [System.Serializable]
    public class Son
    {
        public string nom;
        public AudioClip[] arr_sons;
    }

    // tous les sons à utiliser dans le jeu
    // seront initialisés à la création du manager
    public Son[] sons;
    // tous les audio source prêts à jouer un son
    // plusieurs peuvent être nécessaires car plusieurs sons simultanés possible (e.g. musique+son FX)
    //private List<AudioSource> p_listAudioSource;
    // un dictionnaire pour stocker et accéder aux son du jeu depuis leur nom
    private Dictionary<string, AudioClip[]> p_sons;

    void Awake()
    {
        // ===>> SingletonMAnager
        //Check if instance already exists
        if (p_instance == null)
            //if not, set instance to this
            p_instance = this;
        //If instance already exists and it's not this:
        else if (p_instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        // DontDestroyOnLoad(gameObject);   par nécessaire ici car déja fait par script __DDOL sur l'objet _EGO_app qui recueille tous les mgr
        p_sons = new Dictionary<string, AudioClip[]>();
        foreach (Son _son in sons)
            p_sons.Add(_son.nom, _son.arr_sons);

    }

    // jouer un son du jeu
    // vérifier que le son existe
    // trouver un lecteur libre (audioSource) ou en ajouter un s'ils sont tous en lecture
    // jouer le son sur le lecteur libre (avec le délai fourni)
    public void PlaySound(string __nom, AudioSource audiosource)
    {
        AudioClip[] mesSon = p_sons[__nom];
        AudioClip audio = mesSon[Random.Range(0, mesSon.Length)];
        if (!audiosource.isPlaying)
        {
            audiosource.clip = audio;
            audiosource.Play();
            return;
        }
    }

    public void PlayMusic()
    {
        musique.Play();
    }
}

