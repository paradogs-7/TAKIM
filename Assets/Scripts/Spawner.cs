using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Olu�turulacak nesneler
    public GameObject[] nesnePrefabrikalari;

    // Olu�turma yar��ap� (geni�lik)
    public float olusturmaGenisligi = 10.0f;

    // Olu�turma yar��ap� (y�kseklik)
    public float olusturmaYuksekligi = 5.0f;

    // Olu�turulacak nesne say�s�
    public int olusturmaAdedi = 10;

    void Start()
    {
        NesneleriOlustur();
    }

    void NesneleriOlustur()
    {
        for (int i = 0; i < olusturmaAdedi; i++)
        {
            Vector2 rastgeleKonum = new Vector2(Random.Range(-olusturmaGenisligi / 2.0f, olusturmaGenisligi / 2.0f), Random.Range(-olusturmaYuksekligi / 2.0f, olusturmaYuksekligi / 2.0f));

            int rastgeleIndeks = Random.Range(0, nesnePrefabrikalari.Length);

            Instantiate(nesnePrefabrikalari[rastgeleIndeks], rastgeleKonum, Quaternion.identity);
        }
    }
}