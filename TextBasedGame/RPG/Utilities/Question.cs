using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Utilities
{
    interface Options
    {
        string QuestionText { get; set; }
        string[] Options { get; set; }
    }
    public class Question : Options
    {
        public Question(string _qtext,params string[] _options)
        {
            QuestionText = _qtext;
            Options = _options;
        }
        public string QuestionText { get; set; }
        public string[] Options { get; set; }
    }
}
