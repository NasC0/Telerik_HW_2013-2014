using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : WorldObject, ICourse
    {
        private List<string> topics;

        public Course(string name, ITeacher teacher)
            :base(name)
        {
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(String.Format("{0}: Name={1};", this.GetType().Name, this.Name));

            if (this.Teacher != null)
            {
                result.Append(String.Format(" Teacher={0};", this.Teacher.Name));
            }

            if (this.topics.Count > 0)
            {
                result.Append(String.Format(" Topics=[{0}];", string.Join(", ", this.topics)));
            }

            return result.ToString();
        }
    }
}
