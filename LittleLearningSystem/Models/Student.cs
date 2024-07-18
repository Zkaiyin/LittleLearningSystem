using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public string? Spassword { get; set; }
    public string? SPassword { get; internal set; }
    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();
}
