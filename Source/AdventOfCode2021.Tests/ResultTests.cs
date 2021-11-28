namespace AdventOfCode2021.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class ResultTests
	{
		[Test]
		public void Constructor_SetsDayProperty()
		{
			var sut = new Result(1);

			Assert.AreEqual(1, sut.Day);
		}

		[Test]
		public void FullAnswer_FirstAnswerOnly()
		{
			var sut = new Result(0)
			{
				AnswerPartOne = "Hello"
			};

			Assert.AreEqual("Hello", sut.FullAnswer);
		}

		[Test]
		public void FullAnswer_SecondAnswerOnly()
		{
			var sut = new Result(0)
			{
				AnswerPartTwo = "World"
			};

			Assert.AreEqual("World", sut.FullAnswer);
		}

		[Test]
		public void FullAnswer_BothAnswers()
		{
			var sut = new Result(0)
			{
				AnswerPartOne = "Hello",
				AnswerPartTwo = "World"
			};

			Assert.AreEqual("Hello | World", sut.FullAnswer);
		}
	}
}
