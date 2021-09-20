using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Client : MonoBehaviour
{
    // alchemy
    public GameObject FrozenCrystal;
    public GameObject ThorsOfPlenty;
    public GameObject LittleHelper;
    public GameObject BlueBeat;
    public GameObject HarshRed;
    public GameObject SavingYellow;
    public GameObject QuickChange;
    public GameObject SomethingTricky;
    public GameObject SaveAPack;

    // Elemental
    public GameObject WaterFlower;
    public GameObject DeadlyGrowth;
    public GameObject VineVein;
    public GameObject NightWall;
    public GameObject FireFlower;
    public GameObject MornignRiver;
    public GameObject SandyNeedles;
    public GameObject EarthlyPetrified;
    public GameObject DeepRooted;

    // dark arts
    public GameObject BloodFlower;
    public GameObject ThornsOfLove;
    public GameObject OnlyLove;
    public GameObject BloodPetal;
    public GameObject DeadlyLove;
    public GameObject ResurectionRose;
    public GameObject BrokenHeart;
    public GameObject ShiftyBlood;
    public GameObject ForeverCactus;

    public SpawnPlant spawn;

    public Text TextBox;
    public Dropdown raceDropdown;
    public Dropdown styleDropdown;
    public Dropdown typeDropdown;

    public int style;
    public int race;
    public int type;

    public List<GameObject> list = new List<GameObject>();

    public void CreateButton()
    {
        MagicRequirements requirements = new MagicRequirements();
        requirements.MagicPracticeStyle = styleDropdown.value;
        requirements.MagicalRace = raceDropdown.value;
        requirements.MagicType = typeDropdown.value;

        IMagic p = GetPlant(requirements);
        TextBox.text = p.ToString();
        var curgameobjects = GameObject.FindObjectsOfType<GameObject>();
        foreach(var v in curgameobjects)
        {
            if (v.name.Contains("Clone"))
                Destroy(v.gameObject);
        }
        spawn.Plant(list.Where(plant => plant.name == p.ToString()).SingleOrDefault());
        
    }

    private static IMagic GetPlant(MagicRequirements requirements)
    {
        MagicFactory factory = new MagicFactory(requirements);
        return factory.Create();
    }

}
