using System;
using System.Text.RegularExpressions;
using FunctionalWay.Eithers;
using Xunit;

namespace FunctionalWay.Tests
{
    public class BookTransfer
    {
        public string Bic { get; }
        public DateTime Date { get; }

        public BookTransfer(string bic, DateTime date)
        {
            Bic = bic;
            Date = date;
        }
    }
    
    public class EitherBindTests
    {
        Regex _bicRegex = new Regex("[A-Z]{11}");

        Either<string, BookTransfer> Handle(BookTransfer transfer)
            => F.Right(transfer)
                .Bind(ValidateBic)
                .Bind(ValidateDate);

        Either<string, BookTransfer> ValidateBic(BookTransfer transfer)
        {
            if (!_bicRegex.IsMatch(transfer.Bic))
            {
                return "not in bic format";
            }

            return transfer;
        }

        Either<string, BookTransfer> ValidateDate(BookTransfer transfer)
        {
            if (transfer.Date <= DateTime.Now)
            {
                return "Date is in the past";
            }
            
            return transfer;
        }


        [Fact]
        public void Should_bind_function_calls_passing_correct_value()
        {
            var transfer1 = new BookTransfer("ABCDEFGHIJK", DateTime.Now.AddMinutes(1));
            
            Assert.Equal(F.Right(transfer1).ToString(), Handle(transfer1).ToString());
        }

        [Fact]
        public void Should_bind_function_calls_passing_error()
        {
            var transfer2 = new BookTransfer("11ABaHIJK", DateTime.Now.AddMinutes(1));
            
            Assert.Equal(F.Left("not in bic format").ToString(), Handle(transfer2).ToString());
        }

    }
}