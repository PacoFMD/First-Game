using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosivoEnemigo : MonoBehaviour {

    public GameObject efectoExplosion;
    public GameObject enemigoExplotado;

    public AudioSource fuente;
    public AudioClip sonido;

	void Start () {
        Scene escenaActual = SceneManager.GetActiveScene();
        string nombreEscena = escenaActual.name;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explosion();
        }  
    }

    void Explosion()
    {
        StartCoroutine(ReinicioEscena());
        Instantiate(efectoExplosion, transform.position, transform.rotation);
        Instantiate(enemigoExplotado, transform.position, transform.rotation);
        fuente.PlayOneShot(sonido);
    }

    IEnumerator ReinicioEscena()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Pruebas_Ramses");
    }
}
