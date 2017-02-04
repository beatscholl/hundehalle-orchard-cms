using Orchard.Data.Migration;
using System;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using dsc.CalendarWidget.Models;

namespace dsc.CalendarWidget
{
  public class Migrations : DataMigrationImpl
  {
    public int Create()
    {
      SchemaBuilder.CreateTable("CalendarWidgetPartRecord", table => table
          .ContentPartRecord()
          .Column<int>("QueryId")
      );

      ContentDefinitionManager.AlterPartDefinition(typeof(CalendarWidgetPart).Name,
          builder => builder
              .Attachable()
              .WithDescription("The calendar widget part"));

      ContentDefinitionManager.AlterTypeDefinition("CalendarWidget",
          cfg => cfg
              .WithPart("CalendarWidgetPart")
              .WithPart("CommonPart")
              .WithPart("WidgetPart")
              .WithSetting("Stereotype", "Widget")
              );

      SchemaBuilder.CreateTable("CalendarEventDefinitionRecord",
          table => table
              .ContentPartRecord()
              .Column<string>("TimeZone")
              .Column<DateTime>("StartDateTimeUtc")
              .Column<DateTime>("EndDateTimeUtc")
              .Column<bool>("IsAllDay")
              .Column<string>("Url")
              .Column<bool>("IsRecurring")
      );

      ContentDefinitionManager.AlterPartDefinition(typeof(CalendarEventDefinition).Name,
          builder => builder
              .Attachable()
              .WithDescription("Provides calendar event settings to your content. Use this for displaying events in Calendar Widget")
      );

      return 1;
    }
  }
}