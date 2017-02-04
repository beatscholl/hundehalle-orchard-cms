using Orchard.ContentManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Orchard.Core.Common.ViewModels;
using Orchard.Localization;
using Orchard.Localization.Services;
using System.Linq;

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

    public DateTime? StartDateTime
    {
      get { return Retrieve(r => r.StartDateTime); }
      set { Store(r => r.StartDateTimeUtc, value); }
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
        StartDateTime = CreateActualPropertyValue(value, "StartDateTimeProxy");
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

    public DateTime? EndDateTime
    {
      get { return Retrieve(r => r.EndDateTimeUtc); }
      set { Store(r => r.EndDateTimeUtc, value); }
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
        EndDateTime = CreateActualPropertyValue(value, "EndDateTimeProxy");
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

    private DateTime? CreateActualPropertyValue(DateTimeEditor proxyPropertyValue, string proxyPropertyName)
    {
      DateTime? propertyValue = null;

      // the following date/time handling is based on Orchard.Fields.Drivers.DateTimeFieldDriver
      bool hasDate = !string.IsNullOrEmpty(proxyPropertyValue.Date);
      bool hasTime = !string.IsNullOrEmpty(proxyPropertyValue.Time);
      var propertyDisplayName = T(this.GetPropertyAttribute<DisplayAttribute>(proxyPropertyName));

      if (hasDate && hasTime)
      {
        try
        {
          propertyValue = DateLocalizationServices.ConvertFromLocalizedString(proxyPropertyValue.Date, proxyPropertyValue.Time,
          new Orchard.Localization.Models.DateLocalizationOptions { EnableTimeZoneConversion = true });
        }
        catch
        {
          Updater.AddModelError(PartDefinition.Name + "." + proxyPropertyName, T("{0} could not be parsed as a valid date and time.", propertyDisplayName));
        }
      }
      else
      {
        if (!hasDate && hasTime)
          Updater.AddModelError(PartDefinition.Name + "." + proxyPropertyName, T("{0} requires a date.", propertyDisplayName));
        else
        if (hasDate && !hasTime)
          Updater.AddModelError(PartDefinition.Name + "." + proxyPropertyName, T("{0} requires a time.", propertyDisplayName));
        else
        {
          // consider both fields empty as "no date time selection",
          // if property should be required add [System.ComponentModel.DataAnnotations.Required] to actual property as strangely adding it to proxy property does not work
        }
      }

      return propertyValue;
    }

    private string GetPropertyAttribute<T>(string proxyPropertyName)
    {
      PropertyInfo propertyInfo =  (typeof(CalendarEventDefinition)).GetProperty(proxyPropertyName);
      DisplayAttribute displayAttribute = propertyInfo.GetCustomAttributes(true).FirstOrDefault(a => a is DisplayAttribute) as DisplayAttribute;

      return displayAttribute.Name ?? "";
    }
  }
}
