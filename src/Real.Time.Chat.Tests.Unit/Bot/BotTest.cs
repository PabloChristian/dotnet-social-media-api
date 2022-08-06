using Posterr.Bot;
using Xunit;
using FluentAssertions;

namespace Posterr.Tests.Bot
{
    public class BotTest
    {
        [Fact]
        public void Is_message_invalid_to_call_stock()
        {
            //Act
            var result = BotHelper.IsStockCall("Hello world");

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Is_message_valid_to_call_stock()
        {
            //Act
            var result = BotHelper.IsStockCall("/stock=stock_code");
            
            //Assert
            result.Should().BeTrue();
        }
    }
}
