using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }


        public IResult Update(User user)
        {
            var currentUser = _userDal.Get(u => u.Id == user.Id);
            if (currentUser == null)
            {
                return new ErrorResult(Messages.UserDoesntExists);
            }

            var userForUpdate = user;
            userForUpdate.Status = currentUser.Status;
            userForUpdate.PasswordHash = currentUser.PasswordHash;
            userForUpdate.PasswordSalt = currentUser.PasswordSalt;
            _userDal.Update(userForUpdate);
            return new SuccessResult();
        }

        public IResult ChangeUserPassword(ChangePasswordDto changePasswordDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = GetByMail(changePasswordDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(changePasswordDto.OldPassword, userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorResult(Messages.UserPasswordError);
            }

            HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.PasswordHash = passwordHash;
            userToCheck.Data.PasswordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);
            return new SuccessResult(Messages.PasswordChanged);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }


        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
    }
}