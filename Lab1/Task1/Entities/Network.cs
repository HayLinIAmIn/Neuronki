using Accord.Neuro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Entities
{
	public class Network
	{
		public Layer Layer { get; set; }

		public Network(int inputsCount, int neuronsCount)
		{
			CreateLayer(inputsCount, neuronsCount);
		}

		public void Learn(IEnumerable<Tuple<int[], int>> trainingValues, int epochsMaxCount)
		{
			foreach (var neuron in Layer.Neurons)
			{
				neuron.Learn(trainingValues, epochsMaxCount);
			}
		}

		public int Predict(int[] inputValues)
		{
			foreach (var neuron in Layer.Neurons)
			{
				neuron.CalculateByNetwork(inputValues);
			}

			return Layer.Neurons[0].Output;
		}

		private void CreateLayer(int inputsCount, int neuronsCount)
		{
			var neuronsList = new List<Neuron>();

			for (int i = 0; i < neuronsCount; i++)
			{
				neuronsList.Add(new Neuron(inputsCount));
			}

			Layer = new Layer(neuronsList);
		}


	}
}