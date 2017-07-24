using _01.School.Contracts;
using System;
using System.Collections.Generic;

namespace _01.School
{
    public class Discipline : IComment
    {
        private string name;
        private int lectureNumbers;
        private int exerciseNumbers;

        private ICollection<string> comments;

        public Discipline(string name, int lectureNumbers = 0, int exerciseNumbers = 0)
        {
            this.Name = name;
            this.NumberOfLectures = lectureNumbers;
            this.NumberOfExercises = exerciseNumbers;
            this.comments = new List<string>();

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }
        public int NumberOfLectures
        {
            get
            {
                return this.lectureNumbers;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of lectures cannot be less than 0");
                }
                this.lectureNumbers = value;
            }
        }
        public int NumberOfExercises
        {
            get
            {
                return this.exerciseNumbers;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of exercises cannot be less than 0");
                }
                this.exerciseNumbers = value;
            }
        }

        public ICollection<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public void AddComment(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Comment cannot be null or empty");
            }
            this.comments.Add(text);
        }
    }
}