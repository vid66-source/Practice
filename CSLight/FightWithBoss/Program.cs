using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace FightWithBoss;

class Program
{
    static void Main(string[] args)
    {
        float bossHp = 1500f;
        float bossDmg = 150f;
        float heroHp = 1000f;
        float veilOfShadowsDodge = 0.5f;
        float veilOfShadowsCost = 100f;
        int veilOfShadowsCounter = 0;
        float whispersOfTheAbyssHeal = 150f;
        float eclipseStrikeDmg = 300f;
        float shadowPactCost = 50f;
        float shadowPactIncDmg = 0.25f;
        int shadowPactCounter = 0;
        string spellChoise = "";

        Console.WriteLine("You, the mighty shadow wizard, enter the cave. You see two blood-red eyes gleaming from the darkness, watching you hungrily." +
        " A creature emerges from the shadows, born from the most horrific and cruel depths of hell.\nYou have 4 spells:");

        Console.WriteLine("1. Veil of Shadows - Shadows cloak you, reducing the damage taken by half for the next 3 turns, at the cost of " + veilOfShadowsCost + " hit points, but you lose your turn.");
        Console.WriteLine("2. Eclipse Strike - Deals a powerful shadow strike, dealing " + eclipseStrikeDmg + " damage to the enemy. Can only be used while Veil of Shadows counters on you.");
        Console.WriteLine("3. Whispers of the Abyss - Summons mysterious voices from the darkness, healing you for " + whispersOfTheAbyssHeal + " hit points, but you lose your turn.");
        Console.WriteLine("4. Shadow Pact - The forces of darkness enhance your attack spells, increasing their power by " + shadowPactIncDmg + " when you have Shadow Pact counters on you, but you lose your turn and lose " + shadowPactCost + " hit points.");
        Console.WriteLine("You engage in battle, choose spell number.");

        while (bossHp > 0 || heroHp > 0)
        {
            spellChoise = Console.ReadLine();
            switch (spellChoise)
            {
                case "1":
                    Console.WriteLine("You casted Veil of Shadows. Now you have 3 turns while Demon attacks will be weaker.");
                    heroHp -= veilOfShadowsCost;
                    veilOfShadowsCounter = 3;
                    break;
                case "2":
                    if (veilOfShadowsCounter > 0)
                    {
                        Console.WriteLine("You casted Eclipse Strike. A powerful shadow strike hits the Demon.");
                        if (shadowPactCounter > 0)
                        {
                            bossHp -= ((eclipseStrikeDmg * shadowPactIncDmg) + eclipseStrikeDmg);
                            shadowPactCounter -= 1;
                            veilOfShadowsCounter -= 1;
                        }
                        else
                        {
                            bossHp -= eclipseStrikeDmg;
                            veilOfShadowsCounter -= 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can cast Eclipse Strike only after Veil of Shadows cast.");
                    }
                    break;
                case "3":
                    if (heroHp >= 850)
                    {
                        Console.WriteLine("You casted Whispers of the Abyss. Dark voices heal you.");
                        heroHp = 1000;
                        if (veilOfShadowsCounter > 0)
                        {
                            veilOfShadowsCounter -= 1;
                        }
                    }
                    else if (heroHp < 850)
                    {
                        Console.WriteLine("You casted Whispers of the Abyss. Dark voices heal you.");
                        heroHp += whispersOfTheAbyssHeal;
                        if (veilOfShadowsCounter > 0)
                        {
                            veilOfShadowsCounter -= 1;
                        }
                    }

                    break;
                case "4":
                    Console.WriteLine("You casted Shadow Pact. Dark forces enhance your attacks next 3 turns.");
                    shadowPactCounter = 3;
                    if (veilOfShadowsCounter > 0)
                    {
                        veilOfShadowsCounter -= 1;
                    }
                    break;
                default:
                    Console.WriteLine("Make a right choise");
                    break;
            }
            if (heroHp > 0 && bossHp > 0 && veilOfShadowsCounter > 0)
            {
                heroHp -= bossDmg * veilOfShadowsDodge;
            }
            else if (heroHp > 0 && bossHp > 0 && veilOfShadowsCounter == 0)
            {
                heroHp -= bossDmg;
            }
            else if (bossHp <= 0)
            {
                Console.WriteLine("Glorious victory");
                break;
            }
            else if (heroHp <= 0)
            {
                Console.WriteLine("Disgraceful defeat");
                break;
            }
            Console.WriteLine("Hero has " + heroHp + " hp, " + veilOfShadowsCounter + " Veil of Shadows and " +
            shadowPactCounter + " Shadow Pact counters. Demon Boss has " + bossHp + " hp.");
        }
    }
}
