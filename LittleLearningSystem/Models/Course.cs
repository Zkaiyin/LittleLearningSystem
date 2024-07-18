using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public int? AmountLimit { get; set; }

    public string? CourseWeek { get; set; }

    public string? CourseTime { get; set; }

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();

    public virtual ICollection<Ha> Has { get; set; } = new List<Ha>();
}
