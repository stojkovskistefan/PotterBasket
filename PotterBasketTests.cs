namespace PotterBasket
{
    using System.Collections.Generic;
    using Xunit;

    public class PotterBasketTests
    {
        private float Price(List<int> books)
        {
            var final = new PotterBasket();
            return final.Price(books);
        }
    
        [Fact]
        public void Basket_Is_Empty() => Assert.Equal(0, Price(new List<int>()));

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void One_Book(int bookType) => Assert.Equal(8, Price(new List<int> { bookType }));

        [Fact]
        public void Two_Same_Books() => Assert.Equal(16, Price(new List<int> { 1, 1 }));

        [Fact]
        public void Three_Same_Books() => Assert.Equal(24, Price(new List<int> { 1, 1, 1 }));

        [Fact]
        public void Two_Different_Books() => Assert.Equal(16 * 0.95f, Price(new List<int> { 1, 2 }));

        [Fact]
        public void Three_Different_Books() => Assert.Equal(24 * 0.9f, Price(new List<int> { 1, 3, 5 }));

        [Fact]
        public void Four_Different_Books() => Assert.Equal(32 * 0.8f, Price(new List<int> { 1, 2, 3, 5 }));

        [Fact]
        public void Five_Different_Books() => Assert.Equal(40 * 0.75f, Price(new List<int> { 1, 2, 3, 4, 5 }));

        [Fact]
        public void Two_Same_Books_One_Different() => Assert.Equal(8 + 16 * 0.95f, Price(new List<int> { 1, 1, 2 }));

        [Fact]
        public void Two_Double_Same_Books() => Assert.Equal(2 * (16 * 0.95f), Price(new List<int> { 1, 1, 2, 2 }));

        [Fact]
        public void MixedBasket1() => Assert.Equal(32 * 0.8f + 16 * 0.95f, Price(new List<int> { 1, 1, 2, 3, 4, 4 }));

        [Fact]
        public void MixedBasket2() => Assert.Equal(8 + 40 * 0.75f, Price(new List<int> { 1, 2, 3, 3, 4, 5 }));

        [Fact]
        public void MixedBasket3() => Assert.Equal(2 * (32 * 0.8f), Price(new List<int> { 1, 1, 2, 2, 3, 4, 4, 5 }));

        [Fact]
        public void MixedBasket4() => Assert.Equal(3 * (40 * 0.75f) + 2 * (32 * 0.8f), Price(new List<int> { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5 }));

    }
}