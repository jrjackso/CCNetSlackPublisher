using Moq;
using NUnit.Framework;
using ThoughtWorks.CruiseControl.Core;
using ThoughtWorks.CruiseControl.Remote;

namespace SlackPublisher.Tests.Integration
{
    [TestFixture]
    public class SlackPublisherTests
    {
        private ThoughtWorks.CruiseControl.Core.Publishers.SlackPublisher _publisher;

        [SetUp]
        public void SetUp()
        {
            _publisher = new ThoughtWorks.CruiseControl.Core.Publishers.SlackPublisher
            {
                WebhookUrl =
                    "x" // <-- set this to your own to run integration tests
            };
        }

        private IIntegrationResult MakeResult(IntegrationStatus status, bool succeeded)
        {
            var mockResult = new Mock<IIntegrationResult>();
            mockResult.SetupGet(x => x.ProjectUrl).Returns("http://dev/ccnet");
            mockResult.SetupGet(x => x.ProjectName).Returns("developer");
            mockResult.SetupGet(x => x.Label).Returns("3.2.1122.12297");
            mockResult.SetupGet(x => x.Status).Returns(status);
            mockResult.SetupGet(x => x.Succeeded).Returns(succeeded);
            return mockResult.Object;
        }

        [Test]
        public void TestBuildSuccess()
        {
            IIntegrationResult result = MakeResult(status: IntegrationStatus.Success, succeeded: true);

            _publisher.Run(result);

            //No exception.. Success message on Slack.
        }

        [Test]
        public void TestBuildFailure()
        {
            IIntegrationResult result = MakeResult(status: IntegrationStatus.Failure, succeeded: false);

            _publisher.Run(result);

            //No exception.. Failure message on Slack.
        }
    }
}
