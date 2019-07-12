namespace PotterBasket
{
    using System.Collections.Generic;
    using System.Linq;

    public class PotterBasket
    {
        private float[] discountDictionary = { 1, 0.95f, 0.90f, 0.80f, 0.75f };

        private float[] discountArray = new float [5];

        public float Price(List<int> bookOrder)
        {
            if (!bookOrder.Any() || bookOrder == null)
                return 0.0f;

            var booksInOrder = CountSameBookType(bookOrder);

            SummarizeDiscounts(booksInOrder);

            OptimizeDiscounts();

            return discountArray.Select(finalDiscount()).Sum();
        }

        private System.Func<float, int, float> finalDiscount()
        {
            return (i, j) => 8 * (j + 1) * i * discountDictionary[j];
        }

        private void OptimizeDiscounts()
        {
            while (discountArray[2] > 0 && discountArray[4] > 0)
            {
                discountArray[2]--;
                discountArray[4]--;
                discountArray[3] += 2;
            }
        }

        private void SummarizeDiscounts(int[] orderedBooks)
        {
            while (true)
            {
                if (orderedBooks == null)
                    return;

                var availavableBooks = 0;

                for (var i = 0; i < orderedBooks.Length; i++)
                {
                    if (orderedBooks[i] <= 0)
                        continue;

                    availavableBooks++;
                    orderedBooks[i]--;
                }

                if (availavableBooks <= 0)
                    return;

                discountArray[availavableBooks - 1] +=1;
            }
        }

        private int[] CountSameBookType(IEnumerable<int> bookOrder)
        {
            var orderedBooks = new int[5];

            foreach (var book in bookOrder)
                orderedBooks[book - 1]++;

            return orderedBooks;
        }
    }
}