using Orchard.ContentManagement.Records;
using System;
using System.ComponentModel.DataAnnotations;
namespace dsc.CalendarWidget.Models
{
  public class CalendarEventDefinitionRecord : ContentPartRecord
  {
    public virtual string TimeZone { get; set; }
    [Required] public virtual DateTime? StartDateTimeUtc { get; set; }
    [Required] public virtual DateTime? EndDateTimeUtc { get; set; }
    public virtual bool IsAllDay { get; set; }
    public virtual string Url { get; set; }
    public virtual bool IsRecurring { get; set; }
  }
}
