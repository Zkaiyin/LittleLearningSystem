using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public partial class Ha
{
    public int HasId { get; set; }

    public int? MaterialId { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Material? Material { get; set; }
}
