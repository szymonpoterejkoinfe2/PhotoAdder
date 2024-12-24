using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class ImageForPhraseNotExistException : Exception
    {
        public ImageForPhraseNotExistException(string phrase) : base($"Image for given phrase: {phrase} not found!")
        {
        }

    }
}
