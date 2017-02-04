using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dsc.CalendarWidget.Models;
using Orchard.Time;
using Orchard;
using System.Globalization;

namespace dsc.CalendarWidget.Drivers
{
  public class CalendarEventDefinitionDriver : ContentPartDriver<CalendarEventDefinition>
  {
    private Orchard.Localization.Services.IDateLocalizationServices _dateLocalizationServices;
    private const string TemplateName = "Parts/CalendarEventDefinition";
    private IWorkContextAccessor _workContextAccessor;
    private HttpContextBase _context;

    public Localizer T { get; set; }

    public CalendarEventDefinitionDriver(HttpContextBase context, IWorkContextAccessor workContextAccessor, Orchard.Localization.Services.IDateLocalizationServices dateLocalizationService)
    {
      _workContextAccessor = workContextAccessor;
      _context = context;
      _dateLocalizationServices = dateLocalizationService;
      T = NullLocalizer.Instance;
    }

    protected override string Prefix
    {
      get { return "CalendarEventDefinition"; }
    }

    protected override DriverResult Display(CalendarEventDefinition part, string displayType, dynamic shapeHelper)
    {
      return Combined(
          ContentShape("Parts_CalendarEventDefinition",
              () => shapeHelper.Parts_CalendarEventDefinition(part)),
          ContentShape("Parts_CalendarEventDefinition_Summary",
              () => shapeHelper.Parts_CalendarEventDefinition_Summary(part)),
          ContentShape("Parts_CalendarEventDefinition_SummaryAdmin",
              () => shapeHelper.Parts_CalendarEventDefinition_SummaryAdmin(part))
          );
    }

    protected override DriverResult Editor(CalendarEventDefinition part, dynamic shapeHelper)
    {
      // first, set properties which are required by the code that returns part property values for the view
      part.DateLocalizationServices = _dateLocalizationServices;

      return ContentShape("Parts_CalendarEventDefinition_Edit", () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix));
    }

    protected override DriverResult Editor(CalendarEventDefinition part, IUpdateModel updater, dynamic shapeHelper)
    {
      // first, set properties which are required by the code that handles part property updates executed by aUpdater.TryUpdateModel()
      part.T = T;
      part.Updater = updater;
      part.DateLocalizationServices = _dateLocalizationServices;

      updater.TryUpdateModel(part, Prefix, null, null);

      return Editor(part, shapeHelper);
    }

    protected override void Importing(CalendarEventDefinition part, ImportContentContext context)
    {
      base.Importing(part, context);

      throw new NotImplementedException();
    }
    protected override void Exporting(CalendarEventDefinition part, ExportContentContext context)
    {
      base.Exporting(part, context);

      throw new NotImplementedException();
    }
  }
}