using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class WordManager : IWordService
    {
        private readonly IWordDal _wordDal;

        public WordManager(IWordDal wordDal)
        {
            _wordDal = wordDal;
        }

        public IDataResult<List<Word>> GetAll()
        {
            return new SuccessDataResult<List<Word>>(_wordDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Word> GetById(int wordId)
        {
            return new SuccessDataResult<Word>(_wordDal.Get(u => u.WordId == wordId));
        }

        public IDataResult<Word> GetByName(string wordName)
        {
            return new SuccessDataResult<Word>(_wordDal.Get(u => u.WordName == wordName));
        }
        
        [ValidationAspect(typeof(WordValidator))]
        public IResult Add(Word word)
        {
            var result = BusinessRules.RunBusinessRules(CheckWordIfExists(word.WordName));
            if (result != null)
            {
                return result;
            }

            _wordDal.Add(word);
            return new SuccessResult();
        }

        public IResult Update(Word word)
        {
            _wordDal.Update(word);
            return new SuccessResult();
        }

        public IResult Delete(Word word)
        {
            _wordDal.Delete(word);
            return new SuccessResult();
        }

        private IResult CheckWordIfExists(string wordName)
        {
            var result = _wordDal.GetAll(c => c.WordName == wordName).Any();
            if (!result)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.WordExists);
        }
    }
}