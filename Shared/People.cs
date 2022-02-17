using System;

namespace NetRemoting.Shared
{
    public class People : MarshalByRefObject
    {
        public int Age { get; set; }

        public void SetAge(int age)
        {
            Age = age;
        }
    }
}