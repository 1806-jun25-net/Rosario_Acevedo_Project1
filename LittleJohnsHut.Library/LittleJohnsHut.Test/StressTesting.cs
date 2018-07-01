using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LittleJohnsHut.Test
{
    class StressTesting
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new string[] { "asdf" } };
            yield return new object[] { new string[] { "asdf", "asdfas" } };
            yield return new object[] { new string[] { } };
        }
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void InputTestCreation(string str)
        {
            //arrange
            //act
            //assert 


        }

    }
}
