using Orchard.ContentManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Orchard.Core.Common.ViewModels;
using Orchard.Localization;
using Orchard.Localization.Services;

namespace dsc.CalendarWidget.Models
{
  public class CalendarEventDefinition : ContentPart<CalendarEventDefinitionRecord>
  {

    public Localizer T { get; set; }
    public IUpdateModel Updater { get; set; }
    public IDateLocalizationServices DateLocalizationServices { get; set; }

    public string TimeZone
    {
      get { return Record.TimeZone; }
      set { Record.TimeZone = value; }
    }

    public DateTime? StartDateTimeUtc
    {
      get { return Retrieve(r => r.StartDateTimeUtc); }
      set { Store(r => r.StartDateTimeUtc, value); }
    }

    public DateTime? StartDateTime
    {
      get
      {
        var v = StartDateTimeFromUtc;
        return (v.HasValue) ? (DateTime?)DateLocalizationServices.ConvertToSiteTimeZone(v.Value) : null;
      }
    }

    // This property is needed to render Orchard`s date time editor correctly
    [Display(Name = "Start date time")]
    public DateTimeEditor StartDateTimeProxy
    {
      get
      {
        DateTime? v = StartDateTime;
        var lDateLocalizationOptions = new Orchard.Localization.Models.DateLocalizationOptions { EnableCalendarConversion = false, EnableTimeZoneConversion = false };

        return new DateTimeEditor
        {
          ShowDate = true,
          ShowTime = true,
          Date = v.HasValue ? DateLocalizationServices.ConvertToLocalizedDateString(v.Value, lDateLocalizationOptions) : "",
          Time = v.HasValue ? DateLocalizationServices.ConvertToLocalizedTimeString(v.Value, lDateLocalizationOptions) : ""
        };
      }

      set
      {
        StartDateTimeFromUtc = CreateActualPropertyValue(value, "ValidFromProxy");
      }
    }

    public string StartDate { get; set; }
    public string StartTime { get; set; }

    public bool ShowStartDate
    {
      get { return true; }
    }

    public bool ShowStartTime
    {
      get { return !IsAllDay; }
    }

    public DateTime? EndDateTimeUtc
    {
      get { return Retrieve(r => r.EndDateTimeUtc); }
      set { Store(r => r.EndDateTimeUtc, value); }
    }

    public DateTime? EndDateTime
    {
      get { return Record.EndDateTimeUtc; }
      set { Record.EndDateTimeUtc = value; }
    }
    // This property is needed to render Orchard`s date time editor correctly
    [Display(Name = "End date time")]
    public DateTimeEditor EndDateTimeProxy
    {
      get
      {
        DateTime? v = EndDateTime;
        var lDateLocalizationOptions = new Orchard.Localization.Models.DateLocalizationOptions { EnableCalendarConversion = false, EnableTimeZoneConversion = false };

        return new DateTimeEditor
        {
          ShowDate = true,
          ShowTime = true,
          Date = v.HasValue ? DateLocalizationServices.ConvertToLocalizedDateString(v.Value, lDateLocalizationOptions) : "",
          Time = v.HasValue ? DateLocalizationServices.ConvertToLocalizedTimeString(v.Value, lDateLocalizationOptions) : ""
        };
      }

      set
      {
        EndDateTimeFromUtc = CreateActualPropertyValue(value, "ValidFromProxy");
      }
    }
    public string EndDate { get; set; }
    public string EndTime { get; set; }

    public bool ShowEndDate
    {
      get { return true; }
    }

    public bool ShowEndTime
    {
      get { return !IsAllDay; }
    }

    public bool IsAllDay
    {
      get { return Record.IsAllDay; }
      set { Record.IsAllDay = value; }
    }

    public string Url
    {
      get { return Record.Url; }
      set { Record.Url = value; }
    }

    public bool IsRecurring
    {
      get { return Record.IsRecurring; }
      set { Record.IsRecurring = value; }
    }

    private DateTime? StartDateTimeFromUtc { get; set; }

    private DateTime? EndDateTimeFromUtc { get; set; }

    private DateTime? CreateActualPropertyValue(DateTimeEditor proxyPropertyValue, string proxyPropertyName)
    {
      DateTime? v = null;

      // the following date/time handling is based on Orchard.Fields.Drivers.DateTimeFieldDriver
      bool hasDate = !string.IsNullOrEmpty(proxyPropertyValue.Date);
      bool hasTime = !string.IsNullOrEmpty(proxyPropertyValue.Time);
      var lPropertyName = T(this.GetPropertyAttribute<DisplayAttribute>(proxyPropertyName).Name);

      if (hasDate && hasTime)
      {
        try
        {
          v = DateLocalizationServices.ConvertFromLocalizedString(proxyPropertyValue.Date, proxyPropertyValue.Time,
            new Orchard.Localization.Models.DateLocalizationOptions { EnableTimeZoneConversion = true });
        }
        catch
        {
          Updater.AddModelError(PartDefinition.Name + "." + proxyPropertyName, T("{0} could not be parsed as a valid date and time.", lPropertyName));
        }
      }
      else
      {
        if (!hasDate && hasTime)
          Updater.AddModelError(PartDefinition.Name + "." + proxyPropertyName, T("{0} requires a date.", lPropertyName));
        else
        if (hasDate && !hasTime)
          Updater.AddModelError(PartDefinition.Name + "." + proxyPropertyName, T("{0} requires a time.", lPropertyName));
        else
        {
          // consider both fields empty as "no date time selection",
          // if property should be required add [System.ComponentModel.DataAnnotations.Required] to actual property as strangely adding it to proxy property does not work
        }
      }

      return v;
    }

    private PropertyInfo GetPropertyAttribute<T>(string proxyPropertyName)
    {
      return (typeof(CalendarEventDefinition)).GetProperty(proxyPropertyName);
    }
  }
}
