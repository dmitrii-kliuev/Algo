using Xunit;

namespace Algo.Tests.leetcode
{
    public class MaxProfitUnitTest
    {
        [Theory]
        [InlineData(new[] { 7, 1, 2, 5, 3, 6, 4 }, 7)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
        [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
        [InlineData(new[] { 6, 1, 3, 2, 4, 7 }, 7)] // 3-1=2. 7-2=5
        [InlineData(new[] { 2, 1, 2, 1, 0, 1, 2 }, 3)] // 2-1 = 1, 2 - 0 = 2
        public void Test1(int[] arr, int profit)
        {
            // arrange
            var s = new Solution();

            // act
            var act = s.MaxProfit(arr);

            // assert
            Assert.Equal(act, profit);
        }

        private class Solution
        {
            public int MaxProfit(int[] prices)
            {
                if (prices.Length == 0) return 0;

                var profit = 0;

                /*  Ѕерем i-й элемент(это цена по которой покупаем), ищем следующий элемент больший чем i-й после которого 
                идет меньший элемент.“.е. 1, 2, 4, 5, 3, 4 - подходит 5, присваиваем текущему элементу значение 
                на которое идЄт перепад то есть 3.
                ≈сли при поиске дошли до конца но не нашли больший элемент, то переходим от 0 - вого элемента к 1 - вому 
                и ищем дл€ него и т.д.
                ≈сли при поиске дошли до конца массива, а перепада в нижнюю сторону не случилось то это и будет цена 
                по которой нужно продавать*/
                /*Ќужно искать следующую самую низкую цену после перепада вниз*/
                // { 7, 1, 5, 3, 6, 4 }

                for (int i = 0; i < prices.Length; i++)
                {
                    int? buyPrice = null;

                    // поиск следующей цены по которой покупаем. »щем минимальную до повышени€
                    for (int j = i; j < prices.Length; j++)
                    {
                        // 2, 1, 2, 1, 0, 1, 2
                        if (j < prices.Length - 1 && prices[j] < prices[j + 1])
                        {
                            buyPrice = prices[j];
                            i = j;
                            break;
                        }
                    }

                    for (int j = i + 1; j < prices.Length; j++)
                    {
                        int sellPrice;
                        if (buyPrice != null && prices[j] > buyPrice && j + 1 == prices.Length)
                        {
                            sellPrice = prices[j];
                            profit += sellPrice - buyPrice.Value;
                            i = j;
                            break;
                        }

                        if (buyPrice != null && prices[j] > buyPrice && prices[j + 1] < prices[j])
                        {
                            sellPrice = prices[j];
                            i = j;
                            profit += sellPrice - buyPrice.Value;
                            break;
                        }
                    }
                }

                return profit;
            }
        }
    }


}