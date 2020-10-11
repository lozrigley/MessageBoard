using Messaging.Domain.Model;
using Messaging.Domain.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.UnitTests
{
    public class Validation
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VlaidatorResultIsTrueForPassed()
        {
            var validatorResponse = new ValidResponse
            {
                Code = ValidatorResponseCode.Passed
            };

            Assert.IsTrue(validatorResponse.IsValid);

        }

        [Test]
        public void ValidatorResultIsFalseForNotPassed()
        {
            var validatorResponse = new ValidResponse
            {
                Code = ValidatorResponseCode.MessageNull
            };

            Assert.IsFalse(validatorResponse.IsValid);
            validatorResponse.Code = ValidatorResponseCode.SenderNameTooLong;
            Assert.IsFalse(validatorResponse.IsValid);
            validatorResponse.Code = ValidatorResponseCode.SenderNullOrEmpty;
            Assert.IsFalse(validatorResponse.IsValid);
            validatorResponse.Code = ValidatorResponseCode.TextTooLong;
            Assert.IsFalse(validatorResponse.IsValid);
        }

        [Test]
        public void MessageMustHaveNoNullSender()
        {
            var message = new Message
            {

            };

            var validator = new Validator();
            var response = validator.Validate(message);

            Assert.IsTrue(response.Code == ValidatorResponseCode.SenderNullOrEmpty);
            
        }


        [Test]
        public void SenderMustBeLessThan64Chars()
        {
            var message = new Message
            {
                Sender = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
            };

            Assert.IsTrue(message.Sender.Length == 65);

            var validator = new Validator();
            var response = validator.Validate(message);

            Assert.IsTrue(response.Code == ValidatorResponseCode.SenderNameTooLong);

        }
    }
}
