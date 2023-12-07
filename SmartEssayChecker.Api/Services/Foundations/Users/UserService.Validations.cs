//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Models.Users.Exceptions;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private void ValidationOnAdd(User user)
        {
            ValidateUserNotNull(user);

            Validate(
                (Rule: IsInvalid(user.Id), Parameter: nameof(user.Id)),
                (Rule: IsInvalid(user.Name), Parameter: nameof(user.Name)));
        }

        private void ValidateUserOnModify(User user)
        {
            ValidateUserNotNull(user);

            Validate(
               (Rule: IsInvalid(user.Id), Parameter: nameof(user.Id)),
               (Rule: IsInvalid(user.Name), Parameter: nameof(user.Name)));
        }

        private void ValidateUserId(Guid userId)
        {
            Validate((Rule: IsInvalid(userId), Parameter: nameof(userId)));
        }

        private static dynamic IsInvalid(Guid userId) => new
        {
            Condition = userId == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void ValidateUserNotNull(User user)
        {
            if (user == null)
            {
                throw new NullUserException();
            }
        }

        private static void ValidateStorageUser(User maybeUser, Guid userId)
        {
            if (maybeUser is null)
            {
                throw new NotFoundUserException(userId);
            }
        }

        private static void ValidateAgainstStorageUserOnModify(User user, User storageUser)
        {
            ValidateStorageUser(storageUser, user.Id);

            Validate(
                (Rule: IsInvalid(user.Id), Parameter: nameof(user.Id)),
                (Rule: IsInvalid(user.Name), Parameter: nameof(user.Name)));
        }
        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            invalidUserException.ThrowIfContainsErrors();
        }
    }
}
