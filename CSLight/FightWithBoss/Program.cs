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
        bool veilOfShadowsState = false;
        float whispersOfTheAbyssHeal = 200;
        float eclipseStrikeDmg = 300f;
        float shadowPactCost = 50f;
        float shadowPactIncDmg = 0.25f;
        int shadowPactCounter = 0;
        string spellChoise = "";

        Console.WriteLine("You, the mighty shadow wizard, enter the cave. You see two blood-red eyes gleaming from the darkness, watching you hungrily." +
        " A creature emerges from the shadows, born from the most horrific and cruel depths of hell.\nYou have 4 spells:");

        Console.WriteLine("1. Veil of Shadows - Shadows cloak you, reducing the damage taken by half for the next 3 turns, at the cost of " + veilOfShadowsCost + " hit points, but you lose your turn.");
        Console.WriteLine("2. Eclipse Strike - Deals a powerful shadow strike, dealing " + eclipseStrikeDmg + " damage to the boss. Can only be used while Veil of Shadows is active.");
        Console.WriteLine("3. Whispers of the Abyss - Summons mysterious voices from the darkness, healing you for " + whispersOfTheAbyssHeal + " hit points, but you lose your turn.");
        Console.WriteLine("4. Shadow Pact - The forces of darkness enhance your attack spells, increasing their power by " + shadowPactIncDmg + " for 3 turns, but you lose your turn and lose " + shadowPactCost + " hit points.");
        Console.WriteLine("You engage in battle, choose spell number.");

        while (bossHp != 0 || heroHp != 0)
        {
            spellChoise = Console.ReadLine();
            switch (spellChoise)
            {
                case "1":
                    Console.WriteLine("You casted Veil of Shadows. Now you have 3 turns while Demon attacks will be weaker.");
                    heroHp -= veilOfShadowsCost;
                    veilOfShadowsState = true;
                    veilOfShadowsCounter = 3;
                    break;
                case "2":
                    Console.WriteLine("You casted Eclipse Strike. A powerful shadow strike hits the boss.");
                    if (veilOfShadowsState == true)
                    {
                        if (shadowPactCounter > 0)
                        {
                            bossHp -= (eclipseStrikeDmg*shadowPactIncDmg);
                            shadowPactCounter -= 1;
                        }
                        else
                        {
                            bossHp -= eclipseStrikeDmg;
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("You casted Whispers of the Abyss. Dark voices heal you.");
                    heroHp += whispersOfTheAbyssHeal;
                    break;
                case "4":
                    Console.WriteLine("You casted Shadow Pact. Dark forces enhance your attacks.");
                    shadowPactCounter = 3;
                    break;
            }
            if (veilOfShadowsCounter == 3)
            {
                heroHp -= (bossDmg*veilOfShadowsDodge);
                veilOfShadowsCounter -= 1;
            }
            else if (veilOfShadowsCounter == 4)
            {
                heroHp -= bossDmg;
            }
            Console.WriteLine("Hero has " + heroHp + " hp. Demon Boss has " + bossHp + " hp.");
        }
        if (bossHp <= 0)
        {
            Console.WriteLine("Glorious victory");
        }
        else if (heroHp <= 0)
        {
            Console.WriteLine("Disgraceful defeat");
        }
    }
}
