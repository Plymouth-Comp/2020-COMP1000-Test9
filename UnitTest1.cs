using System;
using System.Collections.Generic;
using Xunit;
using XUnit.Project.Attributes;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Exercise.Tests
{
    [TestCaseOrderer("XUnit.Project.Orderers.PriorityOrderer", "XUnit.Project")]
    public class UnitTest1
    {
        private IReact prog;
        public UnitTest1()
        {
            prog = (IReact)new Program();
        }

        [Fact]
        public void Test0()
        {
            
            Assert.True(typeof(IReact).IsInstanceOfType(prog), $"All tests will only work once the interface is correctly used.");
        }


        [Theory, TestPriority(5)]
        [InlineData("hello", "HELLO")]
        [InlineData("There was a long road, ahead of us.", "THERE WAS A LONG ROAD, AHEAD OF US.")]
        [InlineData("Christmas is upon us", "CHRISTMAS IS UPON US")]
        [InlineData("12345", "12345")]
        [InlineData("FINALLY WE ARE NEARLY DONE!", "FINALLY WE ARE NEARLY DONE!")]
        [InlineData("no rest for the ...", "NO REST FOR THE ...")]
        [InlineData("the end is nigh", "THE END IS NIGH")]
        public void Test1(string values, string result)
        {
            var outcome = prog.ConvertToUpper(values);
            Assert.True(outcome == result, $"You should have returned: <{result}> but did return <{outcome}>.");
        }

        [Theory, TestPriority(4)]
        [InlineData('w', 0)]
        [InlineData('W', 0)]
        [InlineData('a', 3)]
        [InlineData('s', 1)]
        [InlineData('S', 1)]
        [InlineData('A', 3)]
        [InlineData('L', 2)]
        [InlineData('i', 0)]
        [InlineData('d', 2)]
        [InlineData('k', 1)]
        [InlineData('J', 3)]
        public void Test2(char values, int result)
        {
            var outcome = prog.Move(values);
            Assert.True(outcome == result, $"You should have returned: <{result}> but did return <{outcome}>.");
        }

        [Theory, TestPriority(3)]
        [InlineData(0, IReact.MovementDirection.North)]
        [InlineData(3, IReact.MovementDirection.West)]
        [InlineData(1, IReact.MovementDirection.South)]
        [InlineData(2, IReact.MovementDirection.East)]
        public void Test3(int values, IReact.MovementDirection result)
        {
            var outcome = prog.Move(values);
            Assert.True(outcome == result, $"You should have returned: <{result}> but did return <{outcome}>.");
        }


    }
}
