﻿using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            return new Student(username, track);
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            return new Trainer(username, technologies);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {

            return new Course(name, lecturesPerWeek, startingDate);
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            return new Lecture(name, date, trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            ResourceType parseResourceAsEnum;
            Enum.TryParse<ResourceType>(type, true, out parseResourceAsEnum);

            switch (parseResourceAsEnum)
            {
                case ResourceType.Video:
                    return new VideoResource(name, url, currentDate);
                case ResourceType.Presentation:
                    return new PresentationResource(name, url);
                case ResourceType.Demo:
                    return new DemoResource(name, url);
                case ResourceType.Homework:
                    return new HomeworkResource(name, url, currentDate.AddDays(7));
                default: throw new ArgumentException("Invalid lecture resource type");
            }

            //// TODO: Implement this
            //throw new NotImplementedException("LectureResource classes not attached to factory.");
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            return new CourseResult(course, examPoints, coursePoints);
        }
    }
}
