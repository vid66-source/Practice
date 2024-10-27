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
        float heroFullHp;
        float veilOfShadowsDodge = 0.5f;
        float veilOfShadowsCost = 100f;
        int veilOfShadowsCounter = 0;
        float whispersOfTheAbyssHeal = 1500f;
        float eclipseStrikeDmg = 300f;
        float shadowPactCost = 50f;
        float shadowPactIncDmg = 0.25f;
        int shadowPactCounter = 0;
        string spellChoise = "";

        heroFullHp = heroHp;

        Console.WriteLine("You, the mighty shadow wizard, enter the cave. You see two blood-red eyes gleaming from the darkness, watching you hungrily." +
        " A creature emerges from the shadows, born from the most horrific and cruel depths of hell.\nYou have 4 spells:");

        Console.WriteLine("1. Veil of Shadows - Shadows cloak you, reducing the damage taken by half for this and the next 3 turns, at the cost of " + veilOfShadowsCost + " hit points, but you lose your turn.");
        Console.WriteLine("2. Eclipse Strike - Deals a powerful shadow strike, dealing " + eclipseStrikeDmg + " damage to the enemy. Can only be used while Veil of Shadows counters are on you.");
        Console.WriteLine("3. Whispers of the Abyss - Summons mysterious voices from the darkness, healing you for " + whispersOfTheAbyssHeal + " hit points, but you lose your turn.");
        Console.WriteLine("4. Shadow Pact - The forces of darkness enhance your attack spells, increasing their power by " + shadowPactIncDmg + " when you have Shadow Pact are counters on you, but you lose your turn and lose " + shadowPactCost + " hit points.");
        Console.WriteLine("You engage in battle, choose a spell number.");

        while (bossHp > 0 && heroHp > 0)
        {
            bool validChoise = false;
            while (!validChoise)
            {
                Console.WriteLine("Choose your spell (1, 2, 3, or 4):");
                spellChoise = Console.ReadLine();

                switch (spellChoise)
                {
                    case "1":
                        if (heroHp > veilOfShadowsCost)
                        {
                            Console.WriteLine("You casted Veil of Shadows. You lose " + shadowPactCost + " hp, but now you have this and next 3 turns where Demon attacks will be weaker.");
                            heroHp -= veilOfShadowsCost;
                            veilOfShadowsCounter = 3;
                            validChoise = true;
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough hp to cast.");
                        }
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
                            validChoise = true;
                        }
                        else
                        {
                            Console.WriteLine("You can cast Eclipse Strike only with Veil of Shadows counters on you.");
                        }
                        break;

                    case "3":
                        if (heroFullHp == heroHp)
                        {
                            Console.WriteLine("You have maximum HP, you don't need to heal.");
                        }
                        else
                        {
                            heroHp += whispersOfTheAbyssHeal;
                            if (heroHp > heroFullHp)
                            {
                                Console.WriteLine("You casted Whispers of the Abyss. The whispers of dark voices heal you.");
                                heroHp = heroFullHp;
                                if (veilOfShadowsCounter > 0)
                                {
                                    veilOfShadowsCounter -= 1;
                                }
                                validChoise = true;
                            }
                        }
                        break;

                    case "4":
                        if (heroHp > shadowPactCost)
                        {
                            Console.WriteLine("You casted Shadow Pact. You lose " + shadowPactCost + " hp. Dark forces enhance your attacks while Shadow Pact counters on you.");
                            heroHp -= shadowPactCost;
                            shadowPactCounter = 3;
                            if (veilOfShadowsCounter > 0)
                            {
                                veilOfShadowsCounter -= 1;
                            }
                            validChoise = true;
                        }
                        else
                        {
                            Console.WriteLine("You have not enough hp for cast.");
                        }
                        break;

                    default:
                        Console.WriteLine("Please choose a valid spell");
                        break;
                }
            }
            if (heroHp > 0 && bossHp > 0 && veilOfShadowsCounter > 0)
            {
                heroHp -= bossDmg * veilOfShadowsDodge;
                Console.WriteLine("Demon attacks you. You take " + (bossDmg * veilOfShadowsDodge) + " damage.");
            }
            else if (heroHp > 0 && bossHp > 0 && veilOfShadowsCounter == 0)
            {
                heroHp -= bossDmg;
                Console.WriteLine("Demon attacks you. You gained " + bossDmg + " damage.");
            }
            if (bossHp > 0 && heroHp > 0)
            {
                Console.WriteLine("Hero has " + heroHp + " hp, " + veilOfShadowsCounter + " Veil of Shadows and " +
                shadowPactCounter + " Shadow Pact counters. Demon Boss has " + bossHp + " hp.");
            }
        }
        if (bossHp <= 0)
        {
            Console.WriteLine("Demon defeated. Glorious victory.");
        }
        else if (heroHp <= 0)
        {
            Console.WriteLine("You lost. The Demon is eating your dead body. Disgraceful defeat.");
        }
    }
}
