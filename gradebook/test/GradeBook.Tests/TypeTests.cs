using System;
using Xunit;

namespace GradeBook.Tests
{   
    public delegate string WriteLogDelegate(String logMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncremetCount;

            var result = log("Hello!");
            Assert.Equal(3, count);

        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncremetCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void StringBehavesLikeValueType()
        {
            String name = "Aaru";
            String upper = MakeUpperCase(name);

            Assert.Equal("AARU", upper);
            Assert.Equal("Aaru", name);
        }

        private String MakeUpperCase(string Parameter)
        {
           return Parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByRef()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(20,x);
        }

        private void SetInt(ref int y)
        {
            y = 20;
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3,x);
        }

        private void SetInt(int y)
        {
            y = 20;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void ReferenceTypePassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBooksetName(ref book1,"New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void GetBooksetName(ref InMemoryBook book, string name)
        {
             book = new InMemoryBook(name);
        } 


        [Fact]
        public void ReferenceTypePassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBooksetName(book1,"New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBooksetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        } 


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            setName(book1,"New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void setName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name); 
            Assert.NotSame(book1, book2);

        }

        [Fact]
         public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }  
     
}
 