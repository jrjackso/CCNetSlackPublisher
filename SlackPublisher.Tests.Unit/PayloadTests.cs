using NUnit.Framework;

namespace SlackPublisher.Tests.Unit
{
    [TestFixture]
    public class PayloadTests
    {
        [Test]
        public void TestJsonFormat()
        {
            var text = "test";
            var payload = new Payload(text);

            string result = payload.ToJson();

            Assert.That(result, Is.EqualTo(@"payload={""text"": ""test""}"));
        }
    }
}
