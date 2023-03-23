using System.Collections.Generic;
using System.Linq;

namespace Task1.Entities
{
	public class Layer
	{
		public List<Neuron> Neurons { get; set; }

		public int Count => Neurons?.Count ?? 0;

		public Layer(List<Neuron> neurons)
		{
			Neurons = neurons;
		}

		public IEnumerable<int> GetOutputs()
		{
			return Neurons.Select(neuron => neuron.Output);
		}

		public IEnumerable<int> GetSignals()
		{
			return Neurons.Select(neuron => neuron.Output);
		}
	}
}