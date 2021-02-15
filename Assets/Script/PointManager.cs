using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public static PointManager inst;

    public List<Image> imageBoxes;
    public List<Sprite> numbers;
    int points;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
            Destroy(this);
    }

   public void AddPoints()
   {
        points++;

        if(points < 10)
        {
            imageBoxes[1].sprite = numbers[points];
        }
        else if (points < 100)
        {
            imageBoxes[2].gameObject.SetActive(true);

            var first = points / 10;
            var second = points % 10;

            imageBoxes[1].sprite = numbers[first];
            imageBoxes[2].sprite = numbers[second];
        }
        else
        {
            imageBoxes[0].gameObject.SetActive(true);

            var first = points / 100;
            var second = points / 10 % 10;
            var third = points % 100;

            print($"{first} {second} {third}");
            imageBoxes[0].sprite = numbers[first];
            imageBoxes[1].sprite = numbers[second];
            imageBoxes[2].sprite = numbers[third];
        }

        float speed = points / 10;
        speed *= 0.8f;

        LevelManager.inst.speed = speed<1? 1: speed;
   }
}
