using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWordService
    {
        IDataResult<List<Word>> GetAll();
        IDataResult<Word> GetById(int wordId);
        IDataResult<Word> GetByName(string wordName);
        IResult Add(Word word);
        IResult Update(Word word);
        IResult Delete(Word word);
    }
}