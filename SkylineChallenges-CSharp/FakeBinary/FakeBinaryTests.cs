using NUnit.Framework;

namespace SkylineChallenges_CSharp.FakeBinary
{
    [TestFixture]
    public class FakeBinaryTests
    {
        private FakeBinary _binary;

        [SetUp]
        public void SetUp()
        {
            this._binary = new FakeBinary();
        }

        [Test]
        public void TestFakeBinaryConversion()
        {
            Assert.AreEqual("000111000101100001", this._binary.ConvertToFakeBinary("113968212627731429"));
            Assert.AreEqual("010110001001", this._binary.ConvertToFakeBinary("050581339416"));
            Assert.AreEqual("110001010000010110", this._binary.ConvertToFakeBinary("751216092332381592"));
            Assert.AreEqual("11100101000101110", this._binary.ConvertToFakeBinary("77511648343619592"));
            Assert.AreEqual("10110101000", this._binary.ConvertToFakeBinary("83583817242"));
            Assert.AreEqual("1101110001", this._binary.ConvertToFakeBinary("7925981405"));
            Assert.AreEqual("110110011100101011", this._binary.ConvertToFakeBinary("874961289930808479"));
            Assert.AreEqual("0010100111110", this._binary.ConvertToFakeBinary("3052634597771"));
            Assert.AreEqual("110110101000", this._binary.ConvertToFakeBinary("661884506314"));
            Assert.AreEqual("0000011010111010000010", this._binary.ConvertToFakeBinary("3414357262585263012272"));
            Assert.AreEqual("11101000000001", this._binary.ConvertToFakeBinary("76947332024118"));
            Assert.AreEqual("0000101000111", this._binary.ConvertToFakeBinary("3230946022966"));
            Assert.AreEqual("1000001001", this._binary.ConvertToFakeBinary("9110038409"));
            Assert.AreEqual("0101000011111010110111", this._binary.ConvertToFakeBinary("3945114477997391561867"));
            Assert.AreEqual("0000001100", this._binary.ConvertToFakeBinary("1020145914"));
        }

    }
}
