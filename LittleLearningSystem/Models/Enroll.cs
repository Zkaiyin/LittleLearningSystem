using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public partial class Enroll
{
    public int EnrollId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public decimal? Score { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
