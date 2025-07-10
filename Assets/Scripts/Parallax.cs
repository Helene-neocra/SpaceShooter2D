using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 0.1f; // Vitesse de déplacement
    private Transform[] layers;
    private float viewWidth;

    void Start()
    {
        // Assume 2 children : up and down
        layers = new Transform[2];
        layers[0] = transform.GetChild(0);
        layers[1] = transform.GetChild(1);

        // Largeur d’un sprite en unités monde
        viewWidth = layers[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Déplacement de toute la couche
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Si le sprite le plus à haut est totalement hors écran
        if (layers[0].position.y + viewWidth < Camera.main.transform.position.y - viewWidth / 2)
        {
            // Le déplacer au dessus de l’autre sprite
            layers[0].position += Vector3.up * viewWidth * 2;

            // Inverser l’ordre pour que le prochain test se fasse sur l’autre sprite
            Transform temp = layers[0];
            layers[0] = layers[1];
            layers[1] = temp;
        }
    }
}
