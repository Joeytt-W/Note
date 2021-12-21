using System;
using System.Collections.Generic;

namespace MyIenumable
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[2]
            {
                new Student{ Id = 1,Name = "张三"},
                new Student{ Id = 2,Name = "李四"}
            };

            MyList<Student> myStudent = new MyList<Student>(students);
            foreach(Student stu in myStudent)
            {
                Console.WriteLine($"{stu.Id } === {stu.Name}");
            }
        }
    }
}
