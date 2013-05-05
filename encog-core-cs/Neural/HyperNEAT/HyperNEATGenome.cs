﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.Neural.NEAT.Training;
using Encog.Engine.Network.Activation;
using Encog.Util.Obj;
using Encog.Neural.NEAT;
using Encog.MathUtil.Randomize;

namespace Encog.Neural.HyperNEAT
{
    /// <summary>
    /// A HyperNEAT genome.
    /// </summary>
    public class HyperNEATGenome : NEATGenome
    {
        /// <summary>
        /// Build the CPPN activation functions.
        /// </summary>
        /// <param name="activationFunctions">The activation functions collection to add to.</param>
        public static void BuildCPPNActivationFunctions(
                ChooseObject<IActivationFunction> activationFunctions)
        {
            activationFunctions.Add(0.25, new ActivationClippedLinear());
            activationFunctions.Add(0.25, new ActivationBipolarSteepenedSigmoid());
            activationFunctions.Add(0.25, new ActivationGaussian());
            activationFunctions.Add(0.25, new ActivationSIN());
            activationFunctions.FinalizeStructure();
        }

        /// <summary>
        /// Construct a HyperNEAT genome.
        /// </summary>
        public HyperNEATGenome()
        {

        }
        /// <summary>
        /// Construct a HyperNEAT genome from another.
        /// </summary>
        /// <param name="other">The other genome.</param>
        public HyperNEATGenome(HyperNEATGenome other)
            : base(other)
        {

        }

        /// <summary>
        /// Construct a HyperNEAT genome from a list of neurons and links.
        /// </summary>
        /// <param name="neurons">The neurons.</param>
        /// <param name="links">The links.</param>
        /// <param name="inputCount">The input count.</param>
        /// <param name="outputCount"> The output count.</param>
        public HyperNEATGenome(IList<NEATNeuronGene> neurons,
                IList<NEATLinkGene> links, int inputCount,
                int outputCount)
            : base(neurons, links, inputCount, outputCount)
        {

        }

        /// <summary>
        /// Construct a random HyperNEAT genome.
        /// </summary>
        /// <param name="rnd">Random number generator.</param>
        /// <param name="pop">The target population.</param>
        /// <param name="inputCount">The input count.</param>
        /// <param name="outputCount">The output count.</param>
        /// <param name="connectionDensity">The connection densitoy, 1.0 for fully connected.</param>
        public HyperNEATGenome(EncogRandom rnd, NEATPopulation pop,
                int inputCount, int outputCount,
                double connectionDensity)
            : base(rnd, pop, inputCount, outputCount, connectionDensity)
        {


        }
    }
}
