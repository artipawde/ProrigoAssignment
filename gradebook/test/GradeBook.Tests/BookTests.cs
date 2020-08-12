using System;
using Xunit;

namespace GradeBook.Tests
{
    
    public class BookTests
    {
        [Fact]
        public void BookCalculateAnAverageGrade()
        {

            // aarange
            var book = new InMemoryBook("Aaru");
            book.AddGrade(22.2);
            book.AddGrade(33.3);
            book.AddGrade(11.1);
            book.AddGrade(44.4);

            // act
            var result = book.GetStatics();

            // assert
            Assert.Equal(27.75, result.Average);
            Assert.Equal(11.1, result.LowGrade);
            Assert.Equal(44.4, result.HighGrade);

        }
    }  
     
}
 