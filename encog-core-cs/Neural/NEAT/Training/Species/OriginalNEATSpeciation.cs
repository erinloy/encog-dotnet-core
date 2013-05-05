﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.ML.EA.Species;
using Encog.ML.EA.Genome;

namespace Encog.Neural.NEAT.Training.Species
{
    /// <summary>
    /// The original NEAT Speciation Strategy. This is currently the only speciation
    /// strategy implemented by Encog. There are other speciation strategies that
    /// have been proposed (and implemented) for NEAT. One example is k-means.
    /// 
    /// NEAT starts up by creating an initial population of genomes with randomly
    /// generated connections between input and output nodes. Not every input neuron
    /// is necessarily connected, this allows NEAT to determine which input neurons
    /// to use. Once the population has been generated it is speciated by iterating
    /// over this population of genomes. The first genome is placed in its own
    /// species.
    /// 
    /// The second genome is then compared to the first genome. If the compatibility
    /// is below the threshold then the genome is placed into the same species as the
    /// first. If not, the second genome founds a new species of its own. The
    /// remaining genomes follow this same process.
    /// 
    /// -----------------------------------------------------------------------------
    /// http://www.cs.ucf.edu/~kstanley/ Encog's NEAT implementation was drawn from
    /// the following three Journal Articles. For more complete BibTeX sources, see
    /// NEATNetwork.java.
    /// 
    /// Evolving Neural Networks Through Augmenting Topologies
    /// 
    /// Generating Large-Scale Neural Networks Through Discovering Geometric
    /// Regularities
    /// 
    /// Automatic feature selection in neuroevolution
    /// </summary>
    public class OriginalNEATSpeciation : ThresholdSpeciation
    {
        /// <summary>
        /// The adjustment factor for disjoint genes.
        /// </summary>
        public double ConstDisjoint { get; set; }

        /// <summary>
        /// The adjustment factor for excess genes.
        /// </summary>
        public double ConstExcess { get; set; }

        /// <summary>
        /// The adjustment factor for matched genes.
        /// </summary>
        public double ConstMatched { get; set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        public OriginalNEATSpeciation()
        {
            ConstDisjoint = 1;
            ConstExcess = 1;
            ConstMatched = 0.4;
        }

        /// <inheritdoc/>
        public override double GetCompatibilityScore(IGenome gen1,
                IGenome gen2)
        {
            double numDisjoint = 0;
            double numExcess = 0;
            double numMatched = 0;
            double weightDifference = 0;

            NEATGenome genome1 = (NEATGenome)gen1;
            NEATGenome genome2 = (NEATGenome)gen2;

            int genome1Size = genome1.LinksChromosome.Count;
            int genome2Size = genome2.LinksChromosome.Count;
            int n = 1;// Math.max(genome1Size, genome2Size);

            int g1 = 0;
            int g2 = 0;

            while ((g1 < genome1Size) || (g2 < genome2Size))
            {

                if (g1 == genome1Size)
                {
                    g2++;
                    numExcess++;
                    continue;
                }

                if (g2 == genome2Size)
                {
                    g1++;
                    numExcess++;
                    continue;
                }

                // get innovation numbers for each gene at this point
                long id1 = genome1.LinksChromosome[g1].InnovationId;
                long id2 = genome2.LinksChromosome[g2].InnovationId;

                // innovation numbers are identical so increase the matched score
                if (id1 == id2)
                {

                    // get the weight difference between these two genes
                    weightDifference += Math.Abs(genome1.LinksChromosome[g1].Weight
                            - genome2.LinksChromosome[g2].Weight);
                    g1++;
                    g2++;
                    numMatched++;
                }

                // innovation numbers are different so increment the disjoint score
                if (id1 < id2)
                {
                    numDisjoint++;
                    g1++;
                }

                if (id1 > id2)
                {
                    ++numDisjoint;
                    ++g2;
                }

            }

            double score = ((this.ConstExcess * numExcess) / n)
                    + ((this.ConstDisjoint * numDisjoint) / n)
                    + (this.ConstMatched * (weightDifference / numMatched));

            return score;
        }

    }
}
