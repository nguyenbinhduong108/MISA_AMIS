using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.UnitTests
{
    [TestFixture]
    public class CalculaterTests
    {
        /// <summary>
        /// Hàm test cộng 2 số nguyên
        /// </summary>
        /// Author: NBDUONG (11/08/2023)
        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        [TestCase(-1, 7, 6)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue * (long)2)]
        public void Add_ValidIiput_SumTwoNumber(int x, int y, long expectedResult)
        {

            // Act
            var actualResult = new Calculator().Add(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

        
        /// <summary>
        /// Hàm test trừ 2 số nguyên
        /// </summary>
        /// Author: NBDUONG (11/08/2023)
        [TestCase(1, 2, -1)]
        [TestCase(2, 3, -1)]
        [TestCase(-1, 7, -8)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)2 + 1)]
        public void Sub_ValidIiput_MinusTwoNumber(int x, int y, long expectedResult)
        {

            // Act
            var actualResult = new Calculator().Sub(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

        /// <summary>
        /// Hàm test nhân 2 số nguyên
        /// </summary>
        /// Author: NBDUONG (11/08/2023)
        [TestCase(1, 2, 2)]
        [TestCase(2, 3, 6)]
        [TestCase(-1, 7, -7)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)int.MinValue)]
        public void Mul_ValidIiput_MulTwoNumber(int x, int y, long expectedResult)
        {

            // Act
            var actualResult = new Calculator().Mul(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

        /// <summary>
        /// Hàm test chia cho 0
        /// </summary>
        /// Author: NBDUONG (11/08/2023)
        [Test]
        public void Div_ZeroInput_ThrowExeption()
        {
            var y = 0;
            var x = 1;
            var expectedMessage = "Không thể chia cho 0";

            var exeption = Assert.Throws<Exception>(() => new Calculator().Div(x, y));

            Assert.That(exeption.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Hàm test chia 2 số nguyên
        /// </summary>
        /// Autho: NBDUONG (11/08/2023)
        [TestCase(1, 2, 0.5f)]
        [TestCase(1, 3, 1 / (float)3)]
        [TestCase(int.MaxValue, 3,int.MaxValue/(double)3)]
        public void Div_ValidInput_DivTwoNumber(int x, int y, double expectedResult)
        {
            // Act
            var actualResult = new Calculator().Div(x, y);

            // Assert
            Assert.That(Math.Abs(actualResult - expectedResult), Is.LessThan(10e-3));
        }

        /// <summary>
        /// Hàm test tách chuỗi cộng các số nguyên
        /// </summary>
        /// Author: NBDUONG (13/08/2023)
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2,3", 6)]
        [TestCase("1, 2, 3", 6)]
        [TestCase("10, 20, 30", 60)]
        public void Add_StringValue_IntValue(string input, int expectedResult)
        {
            // Act 
            var actualResult = new Calculator().Add(input);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm test tách chuỗi có số âm
        /// </summary>
        /// Author: NBDUONG (13/08/2023)
        [TestCase("1,-2,-3", "Không chấp nhận toán tử âm: -2, -3")]
        [TestCase("1, -2, -3", "Không chấp nhận toán tử âm: -2, -3")]
        public void Add_StringValueNegativeNumbers_Exception(string input, string expectedMessage)
        {
            var exeption = Assert.Throws<ArgumentException>(() => new Calculator().Add(input));

            Assert.That(exeption.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Hàm test tách chuỗi có số âm
        /// </summary>
        /// Author: NBDUONG (18/08/2023)
        [TestCase("1, a, 1", "Giá trị không hợp lệ: a")]
        [TestCase("1, 0, a", "Giá trị không hợp lệ: a")]
        [TestCase("a, 0, 1b", "Giá trị không hợp lệ: a, 1a, ab")]
        public void Add_StringValueString_Exception(string input, string expectedMessage)
        {
            var exeption = Assert.Throws<ArgumentException>(() => new Calculator().Add(input));

            Assert.That(exeption.Message, Is.EqualTo(expectedMessage));
        }
    }
}
