
-- Insert Classrooms
INSERT INTO dbo.Classroom (ClassName) VALUES (N'101');
INSERT INTO dbo.Classroom (ClassName) VALUES (N'102');
INSERT INTO dbo.Classroom (ClassName) VALUES (N'103');

-- Insert Subjects
INSERT INTO dbo.Subject (Name) VALUES (N'ریاضی');
INSERT INTO dbo.Subject (Name) VALUES (N'علوم');
INSERT INTO dbo.Subject (Name) VALUES (N'ادبیات');
INSERT INTO dbo.Subject (Name) VALUES (N'تاریخ');
INSERT INTO dbo.Subject (Name) VALUES (N'جغرافیا');

-- Insert Teachers
INSERT INTO dbo.Teacher (FirstName, LastName, HireDate) VALUES (N'محمد', N'یوسفی', '2020-09-11');
INSERT INTO dbo.Teacher (FirstName, LastName, HireDate) VALUES (N'حسین', N'یوسفی', '2020-09-12');
INSERT INTO dbo.Teacher (FirstName, LastName, HireDate) VALUES (N'زهرا', N'صادقی', '2020-09-13');
INSERT INTO dbo.Teacher (FirstName, LastName, HireDate) VALUES (N'زهرا', N'حسینی', '2020-09-14');
INSERT INTO dbo.Teacher (FirstName, LastName, HireDate) VALUES (N'علی', N'یوسفی', '2020-09-15');

-- Insert Periods
INSERT INTO dbo.Period (WeekDay, StartTime, EndTime) VALUES (1, '9:00:00', '10:00:00');
INSERT INTO dbo.Period (WeekDay, StartTime, EndTime) VALUES (2, '10:00:00', '11:00:00');
INSERT INTO dbo.Period (WeekDay, StartTime, EndTime) VALUES (3, '11:00:00', '12:00:00');
INSERT INTO dbo.Period (WeekDay, StartTime, EndTime) VALUES (4, '12:00:00', '13:00:00');
INSERT INTO dbo.Period (WeekDay, StartTime, EndTime) VALUES (5, '13:00:00', '14:00:00');

-- Insert Teaching Assignments
INSERT INTO dbo.TeachingAssignment (TeacherId, SubjectId, ClassroomId, PeriodId)
VALUES (1, 1, 1, 1);
INSERT INTO dbo.TeachingAssignment (TeacherId, SubjectId, ClassroomId, PeriodId)
VALUES (2, 2, 2, 2);
INSERT INTO dbo.TeachingAssignment (TeacherId, SubjectId, ClassroomId, PeriodId)
VALUES (3, 3, 3, 3);
INSERT INTO dbo.TeachingAssignment (TeacherId, SubjectId, ClassroomId, PeriodId)
VALUES (4, 4, 1, 4);
INSERT INTO dbo.TeachingAssignment (TeacherId, SubjectId, ClassroomId, PeriodId)
VALUES (5, 5, 2, 5);