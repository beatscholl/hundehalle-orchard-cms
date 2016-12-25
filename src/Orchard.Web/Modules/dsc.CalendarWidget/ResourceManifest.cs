using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dsc.CalendarWidget
{
    public class ResourceManifest:IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript("Moment").SetUrl("ext/fullcalendar/moment.min.js", "ext/fullcalendar/moment.js").SetDependencies("jQuery");
            manifest.DefineScript("LangAll").SetUrl("ext/fullcalendar/lang-all.min.js", "ext/fullcalendar/lang-all.js");
            manifest.DefineScript("FullCalendar").SetUrl("ext/fullcalendar/fullcalendar.min.js", "ext/fullcalendar/fullcalendar.js").SetDependencies("Moment", "jQuery");
            manifest.DefineScript("Event").SetUrl("Event.min.js", "Event.js");
            manifest.DefineScript("CalendarWidget").SetUrl("CalendarWidget.min.js", "CalendarWidget.js").SetDependencies("FullCalendar","Event");

            manifest.DefineStyle("FullCalendar").SetUrl("ext/fullcalendar/fullCalendar.min.css", "ext/fullcalendar/fullCalendar.css");
            manifest.DefineStyle("FullCalendarPrint").SetUrl("ext/fullcalendar/fullcalendar.print.min.css", "ext/fullcalendar/fullcalendar.print.css");
            manifest.DefineStyle("CalendarWidget").SetUrl("CalendarWidget.min.css", "CalendarWidget.css").SetDependencies("FullCalendar", "FullCalendarPrint");
        }
    }
}