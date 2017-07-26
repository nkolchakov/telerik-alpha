using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private ICourse course;
        private float examPoints;
        private float coursePoints;

        public CourseResult(ICourse course, string examPoints, string coursePoints)
        {
            this.Course = course;
            this.ExamPoints = float.Parse(examPoints);
            this.CoursePoints = float.Parse(coursePoints);

            this.Grade = DetermineGrade(this.ExamPoints, this.CoursePoints);

        }


        public ICourse Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course should not be null!");
                }
                this.course = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Course result's exam points should be between 0 and 1000!");
                }
                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            private set
            {
                if (value < 0 || value > 125)
                {
                    throw new ArgumentException("Course result's course points should be between 0 and 125!");
                }
                this.coursePoints = value;
            }
        }

        public Grade Grade { get; private set; }

        private Grade DetermineGrade(float examPoints, float coursePoints)
        {
            if (examPoints >= 65 || CoursePoints >= 75)
            {
                return Grade.Excellent;
            }
            if ((examPoints >= 30 && examPoints < 60) ||
                (coursePoints >= 45 && coursePoints < 75))
            {
                return Grade.Passed;
            }

            return Grade.Failed;
        }

        public override string ToString()
        {
            return $"  * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}";
        }
    }
}
