using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData.unit
{
    [ExcludeFromCodeCoverage]  
    public class PhoneValidatorTests
    {
        private readonly PhoneNoService _phoneGenerator = new();

#region Validate PhoneNumber Validator

        //8 digits
        [Fact]
        public void IfValidPhoneNumber_ReturnTrue()
        {   
            const string validNumberToTest = "22222222";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.True(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseEmptyString()
        {
            const string validNumberToTest = "";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidString()
        {
            const string validNumberToTest = "xxx";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidStartingNumber()
        {
            const string validNumberToTest = "99999999";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidLength()
        {
            const string validNumberToTest = "222222222"; //valid starter, 9 numbers
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(20000000)]
        [InlineData(30000000)]
        [InlineData(31000000)]
        [InlineData(40000000)]
        [InlineData(42000000)]
        [InlineData(50000000)]
        [InlineData(53000000)]
        [InlineData(60000000)]
        [InlineData(61000000)]
        [InlineData(71000000)]
        [InlineData(81000000)]
        [InlineData(91000000)]
        [InlineData(93000000)]
        [InlineData(34200000)]
        [InlineData(34400000)]
        [InlineData(34900000)]
        [InlineData(35600000)]
        [InlineData(35700000)]
        [InlineData(35900000)]
        [InlineData(36200000)]
        [InlineData(36500000)]
        [InlineData(36600000)]
        [InlineData(38900000)]
        [InlineData(39800000)]
        [InlineData(43100000)]
        [InlineData(44100000)]
        [InlineData(46200000)]
        [InlineData(46600000)]
        [InlineData(46800000)]
        [InlineData(47200000)]
        [InlineData(47400000)]
        [InlineData(47600000)]
        [InlineData(47800000)]
        [InlineData(48500000)]
        [InlineData(48600000)]
        [InlineData(48800000)]
        [InlineData(48900000)]
        [InlineData(49300000)]
        [InlineData(49600000)]
        [InlineData(49800000)]
        [InlineData(49900000)]
        [InlineData(54200000)]
        [InlineData(54300000)]
        [InlineData(54500000)]
        [InlineData(55100000)]
        [InlineData(55200000)]
        [InlineData(55600000)]
        [InlineData(57100000)]
        [InlineData(57400000)]
        [InlineData(57700000)]
        [InlineData(57900000)]
        [InlineData(58400000)]
        [InlineData(58600000)]
        [InlineData(58700000)]
        [InlineData(58900000)]
        [InlineData(59700000)]
        [InlineData(59800000)]
        [InlineData(62700000)]
        [InlineData(62900000)]
        [InlineData(64100000)]
        [InlineData(64900000)]
        [InlineData(65800000)]
        [InlineData(66200000)]
        [InlineData(66500000)]
        [InlineData(66700000)]
        [InlineData(69200000)]
        [InlineData(69400000)]
        [InlineData(69700000)]
        [InlineData(77100000)]
        [InlineData(77200000)]
        [InlineData(78200000)]
        [InlineData(78300000)]
        [InlineData(78500000)]
        [InlineData(78600000)]
        [InlineData(78800000)]
        [InlineData(78900000)]
        [InlineData(82600000)]
        [InlineData(82700000)]
        [InlineData(82900000)]
        public void TestValidPhoneNumberStarters(int phoneNumber)
        {
            //Arrange
            int[] starters = {2, 30, 31, 40, 41, 42, 50, 51, 52, 53, 60, 61, 71, 81, 91, 92, 93,
                342, 344, 345, 346, 347, 348, 349, 356, 357, 359, 362, 365, 366, 389, 398, 431, 441, 462, 466,  468,  472,  474,  476,  478,  485,
                486,  488, 489,  493, 494, 495, 496,  498, 499,  542, 543,  545,  551, 552, 556, 571, 572, 573, 574, 577, 579, 584, 586, 587, 589,
                597, 598, 627, 629, 641, 649, 658, 662, 663, 664, 665, 667, 692, 693, 694, 697, 771, 772, 782, 783, 785, 786, 788, 789, 826, 827,829};
            bool yes = false;
            //Act
            foreach(int starter in starters)
            {
                if (starter.ToString().Length == 1)
                {
                    if (phoneNumber.ToString()[0].ToString() == starter.ToString())
                    {
                        yes = true;
                        break;
                    }
                }
                if (starter.ToString().Length == 2)
                {
                    if (phoneNumber.ToString()[0] + phoneNumber.ToString()[1].ToString() == starter.ToString())
                    {
                        yes = true;
                        break;
                    }
                }
                if (starter.ToString().Length == 3)
                {
                    if (phoneNumber.ToString()[0].ToString() + phoneNumber.ToString()[1].ToString() + phoneNumber.ToString()[2].ToString() == starter.ToString())
                    {
                        yes = true;
                        break;
                    }
                }
            }
            //Assert
            Assert.True(yes);
        }

        [Theory]
        [InlineData(10000000)]
        [InlineData(32000000)]
        [InlineData(39000000)]
        [InlineData(43000000)]
        [InlineData(49000000)]
        [InlineData(54000000)]
        [InlineData(59000000)]
        [InlineData(62000000)]
        [InlineData(70000000)]
        [InlineData(72000000)]
        [InlineData(80000000)]
        [InlineData(82000000)]
        [InlineData(90000000)]
        [InlineData(94000000)]
        [InlineData(34100000)]
        [InlineData(34300000)]
        [InlineData(35000000)]
        [InlineData(35500000)]
        [InlineData(35800000)]
        [InlineData(36000000)]
        [InlineData(36100000)]
        [InlineData(36300000)]
        [InlineData(36400000)]
        [InlineData(36700000)]
        [InlineData(38800000)]
        [InlineData(39000000)]
        [InlineData(39700000)]
        [InlineData(39900000)]
        [InlineData(43000000)]
        [InlineData(43200000)]
        [InlineData(44000000)]
        [InlineData(44200000)]
        [InlineData(46100000)]
        [InlineData(46300000)]
        [InlineData(46500000)]
        [InlineData(46700000)]
        [InlineData(46700000)]
        [InlineData(46900000)]
        [InlineData(47100000)]
        [InlineData(47300000)]
        [InlineData(47300000)]
        [InlineData(47500000)]
        [InlineData(47500000)]
        [InlineData(47700000)]
        [InlineData(47700000)]
        [InlineData(47900000)]
        [InlineData(48400000)]
        [InlineData(48700000)]
        [InlineData(48700000)]
        [InlineData(49000000)]
        [InlineData(49200000)]
        [InlineData(49700000)]
        [InlineData(54100000)]
        [InlineData(54400000)]
        [InlineData(54600000)]
        [InlineData(55000000)]
        [InlineData(55300000)]
        [InlineData(55500000)]
        [InlineData(55700000)]
        [InlineData(57000000)]
        [InlineData(57500000)]
        [InlineData(57600000)]
        [InlineData(57800000)]
        [InlineData(57800000)]
        [InlineData(58000000)]
        [InlineData(58300000)]
        [InlineData(58500000)]
        [InlineData(58800000)]
        [InlineData(59000000)]
        [InlineData(59600000)]
        [InlineData(59900000)]
        [InlineData(62600000)]
        [InlineData(62800000)]
        [InlineData(62800000)]
        [InlineData(63000000)]
        [InlineData(64000000)]
        [InlineData(64200000)]
        [InlineData(64800000)]
        [InlineData(65000000)]
        [InlineData(65700000)]
        [InlineData(65900000)]
        [InlineData(66100000)]
        [InlineData(66600000)]
        [InlineData(66800000)]
        [InlineData(69100000)]
        [InlineData(69500000)]
        [InlineData(69600000)]
        [InlineData(69800000)]
        [InlineData(77000000)]
        [InlineData(77300000)]
        [InlineData(78100000)]
        [InlineData(78400000)]
        [InlineData(78400000)]
        [InlineData(79000000)]
        [InlineData(82500000)]
        [InlineData(82800000)]
        [InlineData(83000000)]
        public void TestInvalidPhoneNumberStarters(int phoneNumber)
        {
            //Arrange
            int[] starters = {2, 30, 31, 40, 41, 42, 50, 51, 52, 53, 60, 61, 71, 81, 91, 92, 93,
                342, 344, 345, 346, 347, 348, 349, 356, 357, 359, 362, 365, 366, 389, 398, 431, 441, 462, 466,  468,  472,  474,  476,  478,  485,
                486,  488, 489,  493, 494, 495, 496,  498, 499,  542, 543,  545,  551, 552, 556, 571, 572, 573, 574, 577, 579, 584, 586, 587, 589,
                597, 598, 627, 629, 641, 649, 658, 662, 663, 664, 665, 667, 692, 693, 694, 697, 771, 772, 782, 783, 785, 786, 788, 789, 826, 827,829};
            bool yes = false;
            //Act
            foreach (int starter in starters)
            {
                if (starter.ToString().Length == 1)
                {
                    if (phoneNumber.ToString()[0].ToString() == starter.ToString())
                    {
                        yes = true;
                        break;
                    }
                }
                if (starter.ToString().Length == 2)
                {
                    if (phoneNumber.ToString()[0] + phoneNumber.ToString()[1].ToString() == starter.ToString())
                    {
                        yes = true;
                        break;
                    }
                }
                if (starter.ToString().Length == 3)
                {
                    if (phoneNumber.ToString()[0].ToString() + phoneNumber.ToString()[1].ToString() + phoneNumber.ToString()[2].ToString() == starter.ToString())
                    {
                        yes = true;
                        break;
                    }
                }
            }
            //Assert
            Assert.True(!yes);
        }
        #endregion
    }
}
