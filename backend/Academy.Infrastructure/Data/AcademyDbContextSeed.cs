using Academy.Domain.Entities;

namespace Academy.Infrastructure.Data;

public static class AcademyDbContextSeed
{
    public static async Task SeedAsync(AcademyDbContext context)
    {
        Island academicIsland;
        if (!context.Islands.Any())
        {
            academicIsland = new Island
            {
                Name = "Academic Island",
                Description = "Main academic category containing core subjects such as Arabic and English.",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            context.Islands.Add(academicIsland);
            await context.SaveChangesAsync();
        }
        else
        {
            academicIsland = context.Islands.First();
        }

        // Link existing subjects without island to academicIsland
        var existingUnlinkedSubjects = context.Subjects.Where(s => s.IslandId == null).ToList();
        if (existingUnlinkedSubjects.Any())
        {
            foreach (var subject in existingUnlinkedSubjects)
            {
                subject.IslandId = academicIsland.IslandId;
            }
            await context.SaveChangesAsync();
        }

        if (context.Subjects.Any()) return;

        var arabic = new Subject { Code = "AR", Name = "Arabic", IsActive = true, IslandId = academicIsland.IslandId };
        var english = new Subject { Code = "EN", Name = "English", IsActive = true, IslandId = academicIsland.IslandId };
        
        context.Subjects.AddRange(arabic, english);
        await context.SaveChangesAsync();

        var arLevel1 = new Level { SubjectId = arabic.SubjectId, LevelNumber = 1, CreatedAt = DateTime.UtcNow, IsActive = true };
        var arLevel2 = new Level { SubjectId = arabic.SubjectId, LevelNumber = 2, CreatedAt = DateTime.UtcNow, IsActive = true };
        var enLevel1 = new Level { SubjectId = english.SubjectId, LevelNumber = 1, CreatedAt = DateTime.UtcNow, IsActive = true };
        var enLevel2 = new Level { SubjectId = english.SubjectId, LevelNumber = 2, CreatedAt = DateTime.UtcNow, IsActive = true };

        context.Levels.AddRange(arLevel1, arLevel2, enLevel1, enLevel2);
        await context.SaveChangesAsync();

        var tutorial = new Tutorial { LevelId = enLevel1.LevelId, Title = "Basics", CreatedAt = DateTime.UtcNow, IsActive = true };
        context.Tutorials.Add(tutorial);
        await context.SaveChangesAsync();

        var quiz = new Quiz { TutorialId = tutorial.TutorialId, Title = "Alphabet Quiz", CreatedAt = DateTime.UtcNow, IsActive = true };
        context.Quizzes.Add(quiz);
        await context.SaveChangesAsync();

        var q1 = new ChooseQuestion { QuizId = quiz.QuizId, QuestionText = "What is the first letter?", Options = new List<string> { "A", "B", "C" }, CorrectOption = "A", CreatedAt = DateTime.UtcNow, IsActive = true };
        var q2 = new MatchingQuestion { QuizId = quiz.QuizId, QuestionText = "Match cases", Items = new List<string> { "A", "B" }, CorrectMatches = new Dictionary<string, string> { { "A", "a" }, { "B", "b" } }, CreatedAt = DateTime.UtcNow, IsActive = true };
        var q3 = new DragDropQuestion { QuizId = quiz.QuizId, QuestionText = "Drag correct items", Items = new List<string> { "Apple" }, CorrectMatches = new Dictionary<string, string> { { "Fruit", "Apple" } }, CreatedAt = DateTime.UtcNow, IsActive = true };
        var q4 = new CompleteQuestion { QuizId = quiz.QuizId, QuestionText = "C stands for _at", CorrectAnswer = "Cat", CreatedAt = DateTime.UtcNow, IsActive = true };
        
        context.Questions.AddRange(q1, q2, q3, q4);
        await context.SaveChangesAsync();

        var c = new Class { ClassName = "Class 1A", CreatedAt = DateTime.UtcNow, IsActive = true };
        context.Classes.Add(c);
        await context.SaveChangesAsync();

        var s1 = new Student { ClassId = c.ClassId, StudentName = "Ali", CreatedAt = DateTime.UtcNow, IsActive = true };
        var s2 = new Student { ClassId = c.ClassId, StudentName = "Omar", CreatedAt = DateTime.UtcNow, IsActive = true };
        context.Students.AddRange(s1, s2);
        await context.SaveChangesAsync();

        var inst = new Instructor { FullName = "Mr. Smith", SubjectId = english.SubjectId, CreatedAt = DateTime.UtcNow, IsActive = true };
        context.Instructors.Add(inst);
        await context.SaveChangesAsync();

        var teach = new Teach { ClassId = c.ClassId, InstructorId = inst.InstructorId, SubjectId = english.SubjectId };
        context.Teaches.Add(teach);
        await context.SaveChangesAsync();

        var cp = new ClassProgress { ClassId = c.ClassId, SubjectId = english.SubjectId, LevelId = enLevel1.LevelId, Score = 0, UpdatedAt = DateTime.UtcNow };
        context.ClassProgresses.Add(cp);

        var sp = new StudentProgress { StudentId = s1.StudentId, SubjectId = english.SubjectId, CurrentLevelId = enLevel1.LevelId, UpdatedAt = DateTime.UtcNow };
        context.StudentProgresses.Add(sp);
        await context.SaveChangesAsync();
    }
}
