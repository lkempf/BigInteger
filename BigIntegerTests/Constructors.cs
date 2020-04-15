using System;
using Xunit;

namespace BigIntegerTests
{
    public class Constructors
    {
        private Random rand = new Random();

        [Fact]
        public void ctor__Byte_Int32_Int32()
        {
            var rnd = new Random();

            for (var i = 0; i < 500; i++)
            {
                var n = new BigInteger(1);
                n = n * rnd.Next(1, 1000);
                var bytes = n.getBytes();
                var test_bi = new BigInteger(bytes);
                Assert.Equal(n, test_bi);
            }
        }

        [Fact]
        public void TestCtor__Default()
        {
            var bi = new BigInteger();
            Assert.Equal(0, bi);
            Assert.Equal(1, bi.dataLength);
        }

        [Fact]
        public void TestCtor__Int()
        {
            int val;
            BigInteger bi;
            for (int i = 0; i < 10; i++)
            {
                val = rand.Next();
                bi = new BigInteger(val);
                Assert.Equal(val, bi);
            }

        }

        [Fact]
        public void TestCtor__Long()
        {
            byte[] buffer = new byte[8];
            long val;
            BigInteger bi;
            for (int i = 0; i < 10; i++)
            {
                rand.NextBytes(buffer);
                val = BitConverter.ToInt64(buffer, 0);
                bi = new BigInteger(val);
                Assert.Equal(val, bi);
            }
        }

        [Fact]
        public void TestCtor__UInt()
        {
            uint val;
            BigInteger bi;

            for (int i = 0; i < 10; i++)
            {
                val = (uint)rand.Next();
                bi = new BigInteger(val);
                Assert.Equal(val, bi);
            }
        }

        [Fact]
        public void TestCtor__ULong()
        {
            byte[] buffer = new byte[8];
            ulong val;
            BigInteger bi;

            for (int i = 0; i < 10; i++)
            {
                rand.NextBytes(buffer);
                val = BitConverter.ToUInt64(buffer, 0);
                bi = new BigInteger(val);
                Assert.Equal(val, bi);
            }
        }

        [Fact]
        public void TestCtor__BigInteger()
        {
            int val;
            BigInteger bi;

            for (int i = 0; i < 10; i++)
            {
                val = rand.Next();
                bi = new BigInteger(new BigInteger(val));
                Assert.Equal(val, bi);
            }
        }

        [Fact]
        public void TestCtor__String()
        {
            string val;
            BigInteger bi;

            // base 10
            val = "109982";
            bi = new BigInteger(val, 10);
            Assert.Equal(109982, bi);

            val = "-928883";
            bi = new BigInteger(val, 10);
            Assert.Equal(-928883, bi);

            val = "850935480935480938095830958093709273938209472309479237409237509485094860954806854069845096804509546804586";
            bi = new BigInteger(val, 10);
            Assert.Equal(val, bi.ToString());

            val = "-348793875849753983749823794723984729387498237498237948723987498359847698347598379579485759847598459834759834759";
            bi = new BigInteger(val, 10);
            Assert.Equal(val, bi.ToString());

            val = "0";
            bi = new BigInteger(val, 10);
            Assert.Equal(0, bi);

            // base 2, 8, 16
            int num;
            for (int i = 0; i < 10; i++)
            {
                num = rand.Next();

                // base 2
                val = Convert.ToString(num, 2);
                bi = new BigInteger(val, 2);
                Assert.Equal(num, bi);

                // base 8
                val = Convert.ToString(num, 8);
                bi = new BigInteger(val, 8);
                Assert.Equal(num, bi);

                // base 16
                val = Convert.ToString(num, 16);
                bi = new BigInteger(val, 16);
                Assert.Equal(num, bi);
            }

            // base 2
            bi = new BigInteger("110110111001101001101111001010011000100100000001010111110000010001011000001111010001000101110111110110101100001000011101111101000100110100000111111100101001110110110010100000110001010011001000111011100000100001011110001011110010011011100001011101000000011000101000001011110010110101001000001110110110110011000", 2);
            Assert.Equal("894679476989574598347598958957585794859859857984967549867945769457698457698547698547986754968", bi.ToString());

            // base 8
            bi = new BigInteger("16264142112541231452331146623477472230452102413575446332640663612315010124313752434122143211504144257215641", 8);
            Assert.Equal("957985973498573459834769867984275983457939573985735395983698347968745986798475983475983798573985", bi.ToString());

            // base 16
            bi = new BigInteger("72d0c44ab0a6654d93364e7f3a4c4a8850bbec99b5a0d9e299a082a32fd51c2918d1344322bd1ba1", 16);
            Assert.Equal("957985973498573459834769867984275983457939573985735395983698347968745986798475983475983798573985", bi.ToString());

        }

    }
}
