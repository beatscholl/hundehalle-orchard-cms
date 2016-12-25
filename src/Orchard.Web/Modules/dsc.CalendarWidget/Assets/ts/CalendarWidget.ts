/// <reference path="ext/fullcalendar/ifullcalendar.ts" />
/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="event.ts" />

module dsc {
    export class CalendarWidget {
        constructor(Id: string, Events: dsc.Event[]) {
            $('#' + Id).fullCalendar({
                lang: navigator.userLanguage,
                theme: false,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                editable: false,
                timezone: 'local',
                events: Events,
                weekNumbers: false
            });
        }
    }
}