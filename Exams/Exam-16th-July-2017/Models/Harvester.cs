﻿using System;
using System.Text;

public abstract class Harvester : Worker
{
    private double minEnergyRequirement = 0;
    private double maxEnergyRequirement = 20000;
    private double minOreOutput = 0;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public virtual double EnergyRequirement
    {
        get { return this.energyRequirement; }

        protected set
        {
            if (value < minEnergyRequirement || value > maxEnergyRequirement)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }

            this.energyRequirement = value;
        }
    }

    public virtual double OreOutput
    {
        get { return this.oreOutput; }

        protected set
        {
            if (value < minOreOutput)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            this.oreOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}
