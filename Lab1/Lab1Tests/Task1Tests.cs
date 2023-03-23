using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Entities;

namespace Lab1Tests
{
	[TestClass]
	public class Task1Tests
	{
		private IEnumerable<Tuple<int[], int>> _trainingValues;
		private IEnumerable<int> _expectedValues;

		[TestInitialize]
		public void TestInitialize()
		{
			_trainingValues = new List<Tuple<int[], int>>()
			{
				new Tuple<int[], int>(new[] { 0, 0 }, 0),
				new Tuple<int[], int>(new[] { 0, 1 }, 1),
				new Tuple<int[], int>(new[] { 1, 0 }, 0),
				new Tuple<int[], int>(new[] { 1, 1 }, 0)
			};

			_expectedValues = _trainingValues.Select(x => x.Item2);
		}

		[TestMethod]
		public void Lab1Task1_Variant5_SuccessTest()
		{
			var network = new Network(2, 1);
			network.Learn(_trainingValues, 10000);
			var count = 0;

			var expectedValues = _expectedValues.ToList();

			foreach (var inputs in _trainingValues.Select(x => x.Item1))
			{
				var result = network.Predict(inputs);

				Assert.AreEqual(expectedValues[count], result);
				count++;
			}

		}
	}
}
