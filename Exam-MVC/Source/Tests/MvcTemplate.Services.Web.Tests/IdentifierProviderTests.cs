namespace MvcTemplate.Services.Web.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class IdentifierProviderTests
    {
        [Test]
        public void EncodingAndDecodingDoesntChangeTheId()
        {
            const int Id = 1337;
            IIdentifierProvider provider = new IdentifierProvider();
            var encoded = provider.EncodeId(Id, "Pesho makes tests for the exam :) ");
            var actual = provider.DecodeId(encoded);
            Assert.AreEqual(Id, actual);
        }
    }
}
