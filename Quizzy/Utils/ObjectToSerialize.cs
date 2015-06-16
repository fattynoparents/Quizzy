using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{
    [Serializable()]
    public class ObjectToSerialize : ISerializable
    {

        public List<QuestionItem> Template { get; set; }

        public ObjectToSerialize(List<QuestionItem> t)
        {
            Template = t;
        }

        // additional constructor for deserialization
        public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            Template = (List<QuestionItem>)info.GetValue("QuizTemplate", typeof(List<QuestionItem>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("QuizTemplate", Template);
        }
    }
}
