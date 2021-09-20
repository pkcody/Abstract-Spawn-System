using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagicFactory
{
    IMagic Create(MagicRequirements requirements);
}

public class AlchemyFactory : IMagicFactory
{
    public IMagic Create(MagicRequirements requirements)
    {
        // elf
        if (requirements.MagicalRace == 0)
        {
            if (requirements.MagicType == 0) return new FrozenCrystal();
            if (requirements.MagicType == 1) return new ThorsOfPlenty();
            else return new LittleHelper();
        }
        // sorcerer
        if (requirements.MagicalRace == 1)
        {
            if (requirements.MagicType == 0) return new BlueBeat();
            if (requirements.MagicType == 1) return new HarshRed();
            else return new SavingYellow();
        }
        // shapeshifter
        else
        {
            if (requirements.MagicType == 0) return new QuickChange();
            if (requirements.MagicType == 1) return new SomethingTricky();
            else return new SaveAPack();
        }
    }
}

public class ElementalFactory : IMagicFactory
{
    public IMagic Create(MagicRequirements requirements)
    {
    
        // elf
        if (requirements.MagicalRace == 0)
        {
            if (requirements.MagicType == 0) return new WaterFlower();
            if (requirements.MagicType == 1) return new DeadlyGrowth();
            else return new VineVein();
        }
        // sorcerer
        if (requirements.MagicalRace == 1)
        {
            if (requirements.MagicType == 0) return new NightWall();
            if (requirements.MagicType == 1) return new FireFlower();
            else return new MorningRiver();
        }
        // shapeshifter
        else
        {
            if (requirements.MagicType == 0) return new SandyNeedles();
            if (requirements.MagicType == 1) return new EarthlyPetrified();
            else return new DeepRooted();
        }
    }
}

public class DarkArtsFactory : IMagicFactory
{
    public IMagic Create(MagicRequirements requirements)
    {
        // elf
        if (requirements.MagicalRace == 0)
        {
            if (requirements.MagicType == 0) return new BloodFlower();
            if (requirements.MagicType == 1) return new ThornsOfLove();
            else return new OnlyLove();
        }
        // sorcerer
        if (requirements.MagicalRace == 1)
        {
            if (requirements.MagicType == 0) return new BloodPetal();
            if (requirements.MagicType == 1) return new DeadlyLove();
            else return new ResurrectionRose();
        }
        // shapeshifter
        else
        {
            if (requirements.MagicType == 0) return new BrokenHeart();
            if (requirements.MagicType == 1) return new ShiftyBlood();
            else return new ForeverCactus();
        }
    }
}

public abstract class AbstractMagicFactory
{
    public abstract IMagic Create();
}

public class MagicFactory : AbstractMagicFactory
{
    private readonly IMagicFactory _factory;
    private readonly MagicRequirements _requirements;

    public MagicFactory(MagicRequirements requirements)
    {
        if (requirements.MagicPracticeStyle == 0)
            _factory = (IMagicFactory)new AlchemyFactory();
        if (requirements.MagicPracticeStyle == 1)
            _factory = (IMagicFactory)new ElementalFactory();
        else
            _factory = (IMagicFactory)new DarkArtsFactory();
        _requirements = requirements;
    }

    public override IMagic Create()
    {
        return _factory.Create(_requirements);
    }

}