using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;
using Oculus.Voice;
using Meta.WitAi.Json;

public class AnimalSpawner : MonoBehaviour
{
    public AppVoiceExperience voice;
    public Transform spawnPoint;

    [Header("Prefabs de animales")]
    public GameObject cocodriloPrefab;
    public GameObject caballoPrefab;
    public GameObject gallinaPrefab;
    public GameObject elefantePrefab;
    public GameObject gatoPrefab;
    public GameObject perroPrefab;

    private Dictionary<string, GameObject> animalPrefabs;

    void Start()
    {
        animalPrefabs = new Dictionary<string, GameObject>()
        {
            { "cocodrilo", cocodriloPrefab },
            { "caballo", caballoPrefab },
            { "gallina", gallinaPrefab },
            { "elefante", elefantePrefab },
            { "gato", gatoPrefab },
            { "perro", perroPrefab }
        };

        voice.VoiceEvents.OnResponse.AddListener(OnWitResponse);
    }

    void OnDestroy()
    {
        voice.VoiceEvents.OnResponse.RemoveListener(OnWitResponse);
    }

    void OnWitResponse(WitResponseNode response)
    {

        string animal = response.GetFirstEntityValue("animal:animal");

        if (!string.IsNullOrEmpty(animal))
        {
            SpawnAnimal(animal.ToLower());
        }
        else
        {
            Debug.Log("No se detectó animal en la respuesta.");
        }
    }


    void SpawnAnimal(string nombre)
    {
        if (animalPrefabs.ContainsKey(nombre))
        {
            GameObject prefab = animalPrefabs[nombre];

            float margin = 0.5f;
            Vector3 randomOffset = new Vector3(
                Random.Range(-margin, margin),
                0,
                Random.Range(-margin, margin)
            );

            Instantiate(prefab, spawnPoint.position + randomOffset, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No hay prefab asignado para el animal: " + nombre);
        }
    }
}