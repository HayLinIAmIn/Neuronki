using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Entities
{
	public class Neuron
	{
		private const int THRESHOLD = 0;

		private const int BIAS = -1;

		private const double LEARN_SPEED = 0.9;

		public List<double> Weights { get; set; }

		public int Output { get; private set; }

		public Neuron(int inputsCount)
		{
			Weights = new List<double>();

			for (int i = 0; i < inputsCount; i++)
			{
				Weights.Add(1);
			}
		}

		public void Learn(IEnumerable<Tuple<int[], int>> trainingValues, int epochsMaxCount)
		{
			var sumError = 1;
			if (Weights.Count != trainingValues.FirstOrDefault().Item1.Count())
			{
				throw new Exception("Количество весов не соответствует количеству входов");
			}

			var trainingInputs = trainingValues.Select(x => x.Item1).ToList();
			var expectedResults = trainingValues.Select(x => x.Item2).ToList();

			var currentEpoch = 0;

			while (sumError != 0 && epochsMaxCount != currentEpoch)
			{
				currentEpoch++;
				sumError = 0;

				for (var i = 0; i < trainingValues.Count(); i++)
				{
					var networkOutput = CalculateByNetwork(trainingInputs[i]);
					var error = expectedResults[i] - networkOutput;

					for (int j = 0; j < Weights.Count; j++)
					{
						Weights[j] += LEARN_SPEED * error * trainingInputs[i][j];
					}

					sumError += Math.Abs(error);

				}

			}

			Console.WriteLine($"Обучение было закончено на эпохе №{currentEpoch}");
		}

		public int CalculateByNetwork(IEnumerable<int> inputValuesCollection)
		{
			var inputValues = inputValuesCollection.ToList();

			if (Weights.Count != inputValues.Count)
			{
				throw new Exception("Количество весов не соответствует количеству входов");
			}

			var result = 0.0;

			for (var i = 0; i < inputValues.Count(); i++)
			{
				result += Weights[i] * inputValues[i];
			}

			result += BIAS;

			Output = ThresholdActivator(result);

			return Output;
		}

		private int ThresholdActivator(double result)
		{
			return result >= THRESHOLD ? 1 : 0;
		}
	}
}