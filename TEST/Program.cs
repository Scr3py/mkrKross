using System;
using System.IO;
using Xunit; // Простір імен для xUnit
using App; // Простір імен, де знаходиться ваша основна програма

namespace AppTests
{
    public class BinarySequenceServiceTests
    {
        // Тест для підрахунку одиничних бітів
        [Theory]
        [InlineData(7, 3)]  // 7 (бінарно 111) має 3 одиничні біти
        [InlineData(11, 3)] // 11 (бінарно 1011) має 3 одиничні біти
        [InlineData(13, 3)] // 13 (бінарно 1101) має 3 одиничні біти
        [InlineData(14, 3)] // 14 (бінарно 1110) має 3 одиничні біти
        [InlineData(8, 1)]  // 8 (бінарно 1000) має 1 одиничний біт
        [InlineData(15, 4)] // 15 (бінарно 1111) має 4 одиничних біти
        public void CountOnesInBinary_ShouldReturnCorrectCount(int number, int expectedCount)
        {
            // Arrange
          

            // Act
            int result = BinarySequenceService.CountOnesInBinary(number);

            // Assert
            Assert.Equal(expectedCount, result);
        }

        // Тест для знаходження N-го елемента послідовності
        [Theory]
        [InlineData(1, 7)]  // 1-й елемент послідовності: 7
        [InlineData(2, 11)] // 2-й елемент послідовності: 11
        [InlineData(3, 13)] // 3-й елемент послідовності: 13
        [InlineData(4, 14)] // 4-й елемент послідовності: 14
        [InlineData(5, 19)] // 5-й елемент послідовності: 19
        [InlineData(6, 21)] // 6-й елемент послідовності: 21
        [InlineData(7, 22)] // 7-й елемент послідовності: 22
        public void FindNthNumberWithThreeOnes_ShouldReturnCorrectValue(int n, int expectedResult)
        {
            // Arrange
           

            // Act
            int result = BinarySequenceService.FindNthNumberWithThreeOnes(n);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        // Тест для некоректного значення N
        [Fact]
        public void FindNthNumberWithThreeOnes_ShouldThrowArgumentException_WhenNIsZeroOrNegative()
        {
            // Arrange
            

            // Act & Assert
            Assert.Throws<ArgumentException>(() => BinarySequenceService.FindNthNumberWithThreeOnes(0));
            Assert.Throws<ArgumentException>(() => BinarySequenceService.FindNthNumberWithThreeOnes(-1));
        }

        
       
    }
}